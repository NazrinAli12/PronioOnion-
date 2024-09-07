using FluentValidation;
using ProniaOnionTest.Application.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnionTest.Application.Validators
{
    public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is important")
                .MaximumLength(100).WithMessage("Name may consist 100 characters")
                .MinimumLength(2).WithMessage("Name must consist at least 2 characters");

            RuleFor(x => x.SKU)
                .NotEmpty()
                .Must(s => s.Length == 6).WithMessage("SKU must contain only 6 characters");
            RuleFor(x => x.Price)
                .Must(x => x >= 10 && x <= 999999.99m);
            RuleFor(x => x.CategoryId)
                .Must(c => c > 0);
            RuleForEach(x => x.ColorIds).Must(c => c > 0);

            //Proyekti bitirende mesajlari yazarsan

        }
    }
}
