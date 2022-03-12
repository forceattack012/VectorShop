using Identity.Application.DTOs;
using Identity.Domain.Repositories;
using Microsoft.AspNetCore.Authentication;

namespace Identity.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public Task<LoginResponse> Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        //public LoginService(ILoginRepository loginRepository)
        //{
        //    _loginRepository = loginRepository;
        //}

        //public async Task<LoginResponse> Login(string userName, string password)
        //{
        //    var response = new LoginResponse();

        //    try
        //    {
        //        var user = await _loginRepository.FindByUsername(userName);

        //        if (await _loginRepository.ValidateCredentials(user, password))
        //        {
        //            var props = new AuthenticationProperties
        //            {
        //                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
        //                AllowRefresh = true,
        //                RedirectUri = "",
        //            };
        //            await _loginRepository.SignInAsync(user, props);

        //            response.IsSuccess = true;
        //            response.Error = "";
        //        }
        //        else
        //        {
        //            response.IsSuccess = false;
        //            response.Error = "";
        //        }
        //        return response;
        //    }
        //    catch (Exception)
        //    {
        //        return new LoginResponse()
        //        {
        //            IsSuccess = false,
        //            Error = ""
        //        };
        //    }
        //}
    }
}
