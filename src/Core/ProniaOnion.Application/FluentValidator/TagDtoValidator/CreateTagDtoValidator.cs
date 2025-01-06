

using FluentValidation;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.DTOs;

namespace ProniaOnion.Application.FluentValidator
{
    public class CreateTagDtoValidator:AbstractValidator<CreateTagDto>
    {
        private readonly ITagRepository _repository;

        public CreateTagDtoValidator(ITagRepository repository)
        {
            _repository = repository;

            RuleFor(t=>t.Name).NotEmpty()
                    .WithMessage("Name Required")
               .MaximumLength(100)
                    .WithMessage("Must Contains Max 100 symbols")
               .Matches(@"^[A-Za-z]*$")
                    .WithMessage("Wrong Format! Try Again!")
                .MustAsync(CheckName)
                    .WithMessage("This Tag  is already exists"); 
           
        }
        public async Task<bool> CheckName(string name, CancellationToken token)
        {
            return !await _repository.AnyAsync(x => x.Name == name);
        }
    }
}
