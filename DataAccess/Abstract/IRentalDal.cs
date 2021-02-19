using Entities.Concrete;
using Entities.DTOS;
using MyCore.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetRentalDetailDtos(); 
    }
}
