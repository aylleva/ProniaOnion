

using ProniaOnion.Application.DTOs.AppUsersDto;
using ProniaOnion.Application.DTOs.TokenHandler;

namespace ProniaOnion.Application.Abstractions.Services
{
     public interface IAuthenticationService
    {
        Task RegisterAsync(RegisterDto registerDto);

        Task<TokenHandleDto> LoginAsync(LoginDto loginDto);
    }
}
