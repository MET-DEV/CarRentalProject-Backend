using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using Microsoft.EntityFrameworkCore;
using MyCore.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context=new RentACarContext())
            {
                var result=from c in context.Cars join
                           b in context.Brands on
                           c.BrandId equals b.Id
                           select new CarDetailDto {CarId=c.Id,BrandName=b.Name,CarName=c.Name};
                return result.ToList();
            }
            
        }
    }
}
