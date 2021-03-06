using Identity.Domain.Entities;
using Identity.Domain.Repositories;
using Identity.Infrastucture.Constants;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Services;

using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace Identity.Infrastucture.Repositories
{
    public class ProfileRepository : IProfileService, IProfileRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserClaimsPrincipalFactory<User> _claimsFactory;

        public ProfileRepository(UserManager<User> userManager, IUserClaimsPrincipalFactory<User> claimsFactory)
        {
            _userManager = userManager;
            _claimsFactory = claimsFactory;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subject = context.Subject ?? throw new ArgumentNullException(nameof(context.Subject));

            var subjectId = subject.Claims.Where(x => x.Type == "sub").FirstOrDefault().Value;

            var user = await _userManager.FindByIdAsync(subjectId);

            var principal = await _claimsFactory.CreateAsync(user);

            if (user == null)
            {
                throw new ArgumentException("Invalid subject identifier");
            }

            var claims = principal.Claims.ToList();
            claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();
            claims.Add(new Claim(JwtClaimTypes.GivenName, user.Name));
            claims.Add(new Claim(IdentityServerConstants.StandardScopes.Email, user.Email));
            // note: to dynamically add roles (ie. for users other than consumers - simply look them up by sub id
            claims.Add(new Claim(ClaimTypes.Role, Config.Consumer)); // need this for role-based authorization - https://stackoverflow.com/questions/40844310/role-based-authorization-with-identityserver4
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var subject = context.Subject ?? throw new ArgumentNullException(nameof(context.Subject));

            var subjectId = subject.Claims.Where(x => x.Type == "sub").FirstOrDefault().Value;

            var user = await _userManager.FindByIdAsync(subjectId);

            context.IsActive = false;

            if (user != null)
            {
                context.IsActive = true;
            }
        }
    }
}
