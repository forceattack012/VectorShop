using Identity.Domain.Repositories;
using IdentityServer4.Services;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;


namespace Identity.Infrastucture.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private UserManager<TestUser> _userManager;
        private SignInManager<TestUser> _signInManager;

        public LoginRepository(UserManager<TestUser> userManager, SignInManager<TestUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<TestUser> FindByUsername(string user)
        {
            return await _userManager.FindByNameAsync(user);
        }

        public Task SignIn(TestUser user)
        {
            return _signInManager.SignInAsync(user, true);
        }

        public async Task<bool> ValidateCredentials(TestUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public Task SignInAsync(TestUser user, AuthenticationProperties properties, string authenticationMethod = null)
        {
            return _signInManager.SignInAsync(user, properties, authenticationMethod);
        }
    }
}
