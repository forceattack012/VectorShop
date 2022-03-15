using Identity.Domain.Entities;
using Microsoft.AspNetCore.Authentication;

namespace Identity.Domain.Repositories
{
    public interface ILoginRepository
    {
        Task<bool> ValidateCredentials(User user, string password);

        Task<User> FindByUsername(string user);

        Task SignIn(User user);

        Task SignInAsync(User user, AuthenticationProperties properties, string authenticationMethod = null);
    }
}
