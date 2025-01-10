using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.TokenHandler;
using ProniaOnion.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProniaOnion.Infrastructure.Implementations.Services
{
    public class TokenHandlerService : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandlerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TokenHandleDto CreateToken(AppUser user,int minutes)
        {
            SymmetricSecurityKey securitykey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["JWT:secretkey"]));
            

            SigningCredentials credentials = new SigningCredentials(
                securitykey,
                SecurityAlgorithms.HmacSha256
                );

            IEnumerable<Claim> userclaims = new List<Claim> {
                 new Claim(ClaimTypes.NameIdentifier, user.Id),
                 new Claim(ClaimTypes.Name,user.UserName),
                 new Claim(ClaimTypes.GivenName,user.Name),
                 new Claim(ClaimTypes.Surname,user.Surname),
                }; 

            JwtSecurityToken securitytoken = new JwtSecurityToken(
                issuer: _configuration["JWT:issuer"],
                audience: _configuration["JWT:audience"],
                expires:DateTime.Now.AddMinutes(minutes),
                notBefore:DateTime.Now,
                claims:userclaims,
                signingCredentials:credentials
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            string token = handler.WriteToken(securitytoken);

            return new TokenHandleDto(token, user.UserName, DateTime.Now.AddMinutes(30));
        }
    }
}
