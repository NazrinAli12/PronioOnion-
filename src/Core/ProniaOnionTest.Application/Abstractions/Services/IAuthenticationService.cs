using ProniaOnionTest.Application.DTOs.Tokens;
using ProniaOnionTest.Application.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnionTest.Application.Abstractions.Services
{
    public interface IAuthenticationService
    {
        Task Register(RegisterDto dto);
        Task<TokenResponseDto> Login(LoginDto dto);
    }
}
