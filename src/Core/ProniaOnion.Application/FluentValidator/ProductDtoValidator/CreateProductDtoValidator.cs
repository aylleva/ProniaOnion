using FluentValidation;
using ProniaOnion.Application.DTOs.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.FluentValidator.ProductDtoValidator
{
    public class CreateProductDtoValidator:AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty()
                .WithMessage("Name Required")
            .MaximumLength(100)
                .WithMessage("Name must contains max 100 symbols");

            RuleFor(p => p.SKU).NotEmpty()
                .WithMessage("SKU Code Required")
            .MinimumLength(3).MaximumLength(10)
                   .WithMessage("SKU Code must contains min 3,max 10 symbols");

            RuleFor(p => p.Price).NotEmpty()
                    .WithMessage("Price Required")
                .GreaterThanOrEqualTo(3).LessThanOrEqualTo(9999.99m);

            RuleFor(p => p.Description)
                .NotEmpty()
                    .WithMessage("Description Required");

            RuleFor(p => p.CategoryId)
                .NotEmpty()
                    .Must(id => id > 0);

            RuleForEach(p=>p.ColorIds)
                .NotEmpty()
                .Must(id => id > 0);

            RuleForEach(p => p.TagIds)
                .NotEmpty()
                .Must(id => id > 0);

            RuleForEach(p => p.SizeIds)
                .NotEmpty()
                .Must(id => id > 0);

            RuleFor(p => p.ColorIds)
                .Must(c => c.Count > 0);

            RuleFor(p => p.TagIds)
                .Must(c => c.Count > 0);

            RuleFor(p => p.SizeIds)
                .Must(c => c.Count > 0);
        }
    }
}
