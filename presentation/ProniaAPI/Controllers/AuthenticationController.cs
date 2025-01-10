
using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.AppUsersDto;

namespace ProniaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _service;

        public AuthenticationController(IAuthenticationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterDto userdto)
        {
            await _service.RegisterAsync(userdto);
            return NoContent();
        }
        [HttpPost("[Action]")]  
        public async Task<IActionResult> Login([FromForm] LoginDto userdto)
        {
            return Ok(await _service.LoginAsync(userdto));
        }
    }
}
