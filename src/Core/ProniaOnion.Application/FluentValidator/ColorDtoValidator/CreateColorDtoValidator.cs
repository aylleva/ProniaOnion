using FluentValidation;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.DTOs;



namespace ProniaOnion.Application.FluentValidator.ColorDtoValidator
{
    public class CreateColorDtoValidator:AbstractValidator<CreateColorDto>
    {
        private readonly IColorRepository _repository;

        public CreateColorDtoValidator(IColorRepository repository)
        {
            _repository = repository;

            RuleFor(c => c.Name).NotEmpty()
                    .WithMessage("Name Required")
                .MaximumLength(100)
                    .WithMessage("Must Contains max 100 symbols")
                .Matches(@"^[A-Za-z]*$")
                    .WithMessage("Wrong Format! Try Again!")
              .MustAsync(CheckName)
                    .WithMessage("This Color is already exists"); ;

        }

        public async  Task<bool> CheckName(string name,CancellationToken token)
        {
            return !await _repository.AnyAsync(c => c.Name == name);
        }
    }
}
