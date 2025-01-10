using ProniaOnion.Application.DTOs.TokenHandler;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface ITokenHandler
    {
        TokenHandleDto CreateToken(AppUser user,int minutes);
    }
}
