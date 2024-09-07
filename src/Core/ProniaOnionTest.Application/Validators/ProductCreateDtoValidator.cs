using FluentValidation;
using ProniaOnionTest.Application.DTOs.Categories;
using ProniaOnionTest.Application.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnionTest.Application.Validators
{
    public class ProductCreateDtoValidator:AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is important")
                .MaximumLength(100).WithMessage("Name may consist 100 characters")
                .MinimumLength(2).WithMessage("Name must consist at least 2 characters");

            RuleFor(x => x.SKU)
                .NotEmpty().WithMessage("SKU is required")
                .Must(s => s.Length == 6)
                .WithMessage("SKU must contain only 6 characters");
            RuleFor(x => x.Price)
                .Must(CheckPrice)
                .WithMessage("Price must be between 10 and 999999.99.");
            RuleFor(x => x.CategoryId)
                .Must(c => c > 0)
                .WithMessage("Category ID must be greater than 0.");
            RuleForEach(x => x.ColorIds).Must(c => c > 0)
                .WithMessage("Each Color ID must be greater than 0."); 
            //.Must(p >=10 && p <=999999.99m)
            //.LessThanOrEqual(999999.99m).GreaterThanOrEqual(10)
        }
        public bool CheckPrice(decimal price)
        {
            if(price >= 10 && price <= 999999.99m)
            {
                return true;
            }
            return false;
        }
    }
}
