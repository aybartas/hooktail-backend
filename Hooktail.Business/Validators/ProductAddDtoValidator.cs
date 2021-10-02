using FluentValidation;
using Hooktail.Entities.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hooktail.Business.Validation
{
    public class ProductAddDtoValidator: AbstractValidator<ProductAddDto>
    {
        public ProductAddDtoValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("Name of product can not be empty");
            RuleFor(I => I.Price).NotEmpty().WithMessage("Price should be provided.");
            RuleFor(I => I.SubCategoryId).NotEmpty().WithMessage("Category and subcategory should be provided.");
            
        }
    }
}
