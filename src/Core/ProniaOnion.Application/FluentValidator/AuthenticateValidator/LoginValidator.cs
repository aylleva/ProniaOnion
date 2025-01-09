using FluentValidation;
using ProniaOnion.Application.DTOs.AppUsersDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.FluentValidator.AuthenticateValidator
{
    internal class LoginValidator:AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(r => r.UserNameorEmail).NotEmpty()
             .WithMessage(" Required");
             
            RuleFor(r => r.Password).NotEmpty()
           .WithMessage("Incorrent!Try Again!")
            .MinimumLength(8)
           .WithMessage("Incorrent!Try Again!")
          .MaximumLength(100)
               .WithMessage("Incorrent!Try Again!")
               .Must(CheckPassword)
               .WithMessage("Incorrent!Try Again!");
        }

        private bool CheckPassword(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsLower(password[i]) && Char.IsUpper(password[i]) && Char.IsDigit(password[i])) return true;
            }
            return false;
        }
    }
}
