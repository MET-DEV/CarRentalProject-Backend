
using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccess.Abstract;
using Business.Concrete;
using DataAccess.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
       

        public RentalValidator()
        {
            
            RuleFor(r => r.CarId).NotEmpty().WithMessage(Messages.FreeArea);
            //RuleFor(r => r.ReturnDate).Null().WithMessage(Messages.VehicleIsBusy);
            
            
            
        }

       
    }
}
