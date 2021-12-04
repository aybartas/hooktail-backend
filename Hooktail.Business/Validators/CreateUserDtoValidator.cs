using FluentValidation;
using Hooktail.Entities.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hooktail.Business.Validators
{
    public class CreateUserDtoValidator: AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(I => I.Username).NotEmpty().WithMessage("Username can not be empty");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Password can not be empty");

        }
    }
}
