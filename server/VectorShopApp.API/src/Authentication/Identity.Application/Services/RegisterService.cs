using Identity.Application.DTOs;
using Identity.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Services
{
    public class RegisterService : IRegisterService
    {
        private IRegisterRepository _registerRepository;

        public RegisterService(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }

        public async Task<RegisterResponse> RegisterAsync(string email, string password)
        {
            try
            {
                var user = await _registerRepository.RegisterAsync(email, password);
                if (user == null)
                {
                    return new RegisterResponse()
                    {
                        IsSuccess = false,
                    };
                }

                return new RegisterResponse()
                {
                    IsSuccess = true,
                    User = user
                };
            }
            catch (Exception)
            {
                return new RegisterResponse()
                {
                    IsSuccess = false
                };
            }
        }
    }
}
