using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using MyCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage(Messages.FreeArea);
            RuleFor(u => u.LastName).NotEmpty().WithMessage(Messages.FreeArea);
            
            
        }
    }
}
