using Entities.Concrete;
using Entities.DTOS;
using MyCore.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IDataResult<List<Rental>> GetAllRentals();
        IDataResult<Rental> GetById(int rentalId);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();

    }
}
