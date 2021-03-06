using Identity.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Services
{
    public interface ILoginService
    {
        Task<LoginResponse> Login(string userName, string password);
    }
}
