using FluentValidation;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.DTOs.GenreDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.FluentValidator.GenreDtoValidator
{
    public class CreateGenreDtoValidator:AbstractValidator<CreateGenreDto>
    {
        private readonly IGenreRepository _repository;

        public CreateGenreDtoValidator(IGenreRepository repository)
        {
            _repository = repository;

            RuleFor(a => a.Name).NotEmpty()
                    .WithMessage("Name Required")
               .MaximumLength(50)
                    .WithMessage("Name must contains max 50 symbols")
               .Matches(@"^[A-Za-z]*$")
                    .WithMessage("Wrong Format! Try Again!")
               .MustAsync(CheckName)
                    .WithMessage("This Genre Type is already exists");
           
        }
        public async Task<bool> CheckName(string name, CancellationToken token)
        {
            return !await _repository.AnyAsync(x => x.Name == name);
        }
    }
}
