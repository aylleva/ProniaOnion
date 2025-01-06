

using FluentValidation;
using ProniaOnion.Application.DTOs;

namespace ProniaOnion.Application.FluentValidator
{
    public class CreateTagDtoValidator:AbstractValidator<CreateTagDto>
    {
        public CreateTagDtoValidator()
        {
            RuleFor(t=>t.Name).NotEmpty().WithMessage("Name Required")
                .MaximumLength(100).WithMessage("Must Contains Max 100 symbols")
                .Matches(@"^[A-Za-z]*$").WithMessage("Wrong Format! Try Again!");
        }
    }
}
