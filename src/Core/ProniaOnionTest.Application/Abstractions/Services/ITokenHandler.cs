using ProniaOnionTest.Application.DTOs.Tokens;
using ProniaOnionTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnionTest.Application.Abstractions.Services
{
    public interface ITokenHandler
    {
        TokenResponseDto CreateToken(AppUser user, int minutes);
    }
}
