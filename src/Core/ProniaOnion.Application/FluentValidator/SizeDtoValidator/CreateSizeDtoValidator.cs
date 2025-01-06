
using FluentValidation;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.DTOs;

namespace ProniaOnion.Application.FluentValidator.SizeDtoValidator
{
   public class CreateSizeDtoValidator:AbstractValidator<CreateSizeDto>
    {
        private readonly ISizeRepository _repository;

        public CreateSizeDtoValidator(ISizeRepository repository)
        {
            _repository = repository;

            RuleFor(s=>s.Name).NotEmpty()
                    .WithMessage("Name Required")
                .MaximumLength(50)
                    .WithMessage("Must Contains Max 50 symbols")
                .Matches(@"^[A-Za-z\s]*$")
                    .WithMessage("Wrong Format! Try Again!")
                 .MustAsync(CheckName)
                    .WithMessage("This Size Type is already exists"); 
          
        }
        public async Task<bool> CheckName(string name, CancellationToken token)
        {
            return !await _repository.AnyAsync(x => x.Name == name);
        }
    }
}
