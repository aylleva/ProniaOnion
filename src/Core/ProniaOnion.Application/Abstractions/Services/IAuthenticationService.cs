

using ProniaOnion.Application.DTOs.AppUsersDto;

namespace ProniaOnion.Application.Abstractions.Services
{
     public interface IAuthenticationService
    {
        Task Register(RegisterDto registerDto);

        Task Login(LoginDto loginDto);
    }
}
