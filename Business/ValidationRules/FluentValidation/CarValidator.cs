using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(Messages.FreeArea);
            RuleFor(c => c.Name).MinimumLength(2).WithMessage(Messages.MinLength);
            RuleFor(c => c.DailyPrice).GreaterThan(50).WithMessage(Messages.PriceIsLow);
            
        }

        
    }
}
