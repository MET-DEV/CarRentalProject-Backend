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

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result = _rentalDal.GetAll(r=>r.CarId==rental.CarId && rental.ReturnDate==null);
            
            
             _rentalDal.Add(rental);
              return new SuccessDataResult(Messages.RentAdded);
        }

        public IDataResult<List<Rental>> GetAllRentals()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.Id==rentalId));
        }

        

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetailDtos(),Messages.DetailListed);
        }
    }
}
