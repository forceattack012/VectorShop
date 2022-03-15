using Identity.Domain.Entities;
using Identity.Domain.Repositories;
using IdentityServer4.Services;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;


namespace Identity.Infrastucture.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public LoginRepository(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<User> FindByUsername(string user)
        {
            return await _userManager.FindByNameAsync(user);
        }

        public Task SignIn(User user)
        {
            return _signInManager.SignInAsync(user, true);
        }

        public async Task<bool> ValidateCredentials(User user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public Task SignInAsync(User user, AuthenticationProperties properties, string authenticationMethod = null)
        {
            return _signInManager.SignInAsync(user, properties, authenticationMethod);
        }
    }
}
