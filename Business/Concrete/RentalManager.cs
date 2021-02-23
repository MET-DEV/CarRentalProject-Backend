using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using MyCore.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MyCore.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = _rentalDal.GetAll(c => c.CarId == rental.CarId && c.ReturnDate >=DateTime.MinValue).ToList();


            if (result.Count == 0)
            {

                return new ErrorResult(Messages.VehicleIsBusy);
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessDataResult(Messages.RentAdded);
            }


        }

        public IDataResult<List<Rental>> GetAllRentals()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
        }



        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetailDtos(), Messages.DetailListed);
        }
    }
}
