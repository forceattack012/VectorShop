using IdentityServer4.Test;
using Microsoft.AspNetCore.Authentication;

namespace Identity.Domain.Repositories
{
    public interface ILoginRepository
    {
        Task<bool> ValidateCredentials(TestUser user, string password);

        Task<TestUser> FindByUsername(string user);

        Task SignIn(TestUser user);

        Task SignInAsync(TestUser user, AuthenticationProperties properties, string authenticationMethod = null);
    }
}
