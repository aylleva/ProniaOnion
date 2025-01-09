
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.AppUsersDto;
using ProniaOnion.Domain.Entities;
using System.Text;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser> _usermeneger;
        private readonly IMapper _mapper;

        public AuthenticationService(UserManager<AppUser> usermeneger,IMapper mapper)
        {
           _usermeneger = usermeneger;
            _mapper = mapper;
        }
        public async Task Register(RegisterDto registerDto)
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
            }

            throw new Exception(str.ToString());
           
        }

        public async Task Login(LoginDto loginDto)
        {
           AppUser? user=await _usermeneger.Users.FirstOrDefaultAsync(u=>u.UserName==loginDto.UserNameorEmail||u.Email==loginDto.UserNameorEmail);
            if (user == null) throw new Exception("UserName/Email or Password is incorrect!");

            bool result=await _usermeneger.CheckPasswordAsync(user,loginDto.Password);
            if (!result)
            {
                await _usermeneger.AccessFailedAsync(user);
                throw new Exception("UserName/Email or Password is incorrect!");
            }
              
        }


        //private string Capitalize(string str)
        //{
        //   return str = char.ToUpper(str[0])+str.Substring(1);
        //}
    }
}
