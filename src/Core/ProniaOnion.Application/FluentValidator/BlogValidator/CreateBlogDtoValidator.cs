using FluentValidation;
using ProniaOnion.Application.DTOs.BlogDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.FluentValidator.BlogValidator
{
    public class CreateBlogDtoValidator:AbstractValidator<CreateBlogDto>
    {
        public CreateBlogDtoValidator()
        {
            RuleFor(b=>b.Title).NotEmpty().WithMessage("Title Required")
                .MaximumLength(100).WithMessage("Must Contains max 100 symbols")
                .Matches(@"^[A-Za-z\s0-9]*$");
            RuleFor(b => b.Article).NotEmpty().WithMessage("Article Required")
              .MaximumLength(200).WithMessage("Must Contains max 200 symbols")
              .Matches(@"^[A-Za-z\s0-9]*$");

        }
    }
}
