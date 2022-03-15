using Identity.Domain.Entities;

namespace Identity.Domain.Repositories
{
    public interface IRegisterRepository
    {
        Task<User> RegisterAsync(string userName, string password);
    }
}
