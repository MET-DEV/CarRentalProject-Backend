using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOS;
using MyCore.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetailDtos()
        {
            using (RentACarContext context=new RentACarContext())
            {
                var result=from cs in context.Cars join
                           r in context.Rentals on
                           cs.Id equals r.CustomerId
                           join un in context.Users on
                           r.CustomerId equals un.Id
                           select new RentalDetailDto {CarName=cs.Name,CustomerName=un.FirstName+" "+un.LastName,RentDate=r.RentDate,CarId=r.CarId };
                return result.ToList();
            }
        }
    }
}
