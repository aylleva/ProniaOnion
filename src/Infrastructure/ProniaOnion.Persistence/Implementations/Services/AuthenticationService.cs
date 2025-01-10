
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.AppUsersDto;
using ProniaOnion.Application.DTOs.TokenHandler;
using ProniaOnion.Domain.Entities;
using System.Text;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser> _usermeneger;
        private readonly IMapper _mapper;
        private readonly ITokenHandler _token;

        public AuthenticationService(UserManager<AppUser> usermeneger,IMapper mapper,ITokenHandler token)
        {
           _usermeneger = usermeneger;
            _mapper = mapper;
            _token = token;
        }
        public async Task RegisterAsync(RegisterDto registerDto)
        {
            if (await _usermeneger.Users.AnyAsync(u => u.UserName == registerDto.UserName || u.Email == registerDto.Email)) 
            throw new Exception("UserName or Email is already exist");

            var result = await _usermeneger.CreateAsync(_mapper.Map<AppUser>(registerDto), registerDto.Password);
        
            StringBuilder str= new StringBuilder();
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    str.AppendLine(error.Description);
                }
                throw new Exception(str.ToString());
            }


        }

        public async Task<TokenHandleDto> LoginAsync(LoginDto loginDto)
        {
           AppUser? user=await _usermeneger.Users.FirstOrDefaultAsync(u=>u.UserName==loginDto.UserNameorEmail||u.Email==loginDto.UserNameorEmail);
            if (user == null) throw new Exception("UserName/Email or Password is incorrect!");

            bool result=await _usermeneger.CheckPasswordAsync(user,loginDto.Password);
            if (!result)
            {
                await _usermeneger.AccessFailedAsync(user);
                throw new Exception("UserName/Email or Password is incorrect!");
            }

            return _token.CreateToken(user, 30);
        }


    }
}
