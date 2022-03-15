using Identity.Domain.Entities;
using Identity.Domain.Repositories;
using Identity.Infrastucture.Constants;
using Microsoft.AspNetCore.Identity;

namespace Identity.Infrastucture.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private UserManager<User> _userManager;

        public RegisterRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> RegisterAsync(string email, string password)
        {
            User user = new User
            {
                UserName = email,
                Email = email,
            };

            await _userManager.CreateAsync(user,password);

            await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("userName", user.UserName));
            await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("email", user.Email));
            await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("role", Config.Consumer));

            return user;
        }
    }
}
