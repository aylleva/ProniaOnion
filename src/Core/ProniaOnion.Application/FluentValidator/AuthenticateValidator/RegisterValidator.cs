

using FluentValidation;
using ProniaOnion.Application.DTOs.AppUsersDto;

namespace ProniaOnion.Application.FluentValidator.AuthenticateValidator
{
    public class RegisterValidator:AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(r=>r.Name).NotEmpty()
                .WithMessage("Name Required")
            .MinimumLength(3)
               .WithMessage("Name must exist min 3 length")
               .MaximumLength(30)
                    .WithMessage("Name must exist max 30 length")
                .Matches(@"^[A-Za-z]*$")
                       .WithMessage("Incorrect Format! Do not use any symbols or numbers");

            RuleFor(r => r.Surname).NotEmpty()
               .WithMessage("Surname Required")
                .MinimumLength(6)
               .WithMessage("Surname must exist min 6 length")
              .MaximumLength(50)
                   .WithMessage("Surname must exist max 50 length")
               .Matches(@"^[A-Za-z]*$")
                      .WithMessage("Incorrect Format! Do not use any symbols or numbers");

            RuleFor(r => r.UserName).NotEmpty()
               .WithMessage("Username Required")
                .MinimumLength(4)
               .WithMessage(" Username must exist min 4 length")
              .MaximumLength(256)
                   .WithMessage("Name must exist max 256 length")
               .Matches(@"^[A-Za-z0=9_@.]*$")
                      .WithMessage("Incorrect Format!");

            RuleFor(r => r.Email).NotEmpty()
              .WithMessage("Email Required")
               .MinimumLength(10)
              .WithMessage("Email must exist min 10 length")
             .MaximumLength(256)
                  .WithMessage("Email must exist max 256 length")
              .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                     .WithMessage("Incorrect Format!");

            RuleFor(r => r.Password).NotEmpty()
           .WithMessage("Password Required")
            .MinimumLength(8)
           .WithMessage("Password must exist min 8 length")
          .MaximumLength(100)
               .WithMessage("Password must exist max 100 length")
               .Must(CheckPassword)
               .WithMessage("Password must exist least 1 Upper letter,1 Lower letter and 1 Digit");
        }

        private bool CheckPassword(string password)
        {
            for(int i=0;i<password.Length;i++)
            {
                if (Char.IsLower(password[i]) && Char.IsUpper(password[i]) && Char.IsDigit(password[i])) return true;
            }
            return false;
        }
    }
}
