using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using MyCore.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetailDtos()
        {
            using (RentACarContext context=new RentACarContext())
            {
                var result=from u in context.Users join
                           c in context.Customers on
                           u.Id equals c.UserId
                           select new CustomerDetailDto { CustomerName=u.FirstName,CustomerLastName=u.LastName,CustomerMailAdress=u.Email};
                return result.ToList();
            }
        }
    }
}
