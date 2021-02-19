using Business.Abstract;
using DataAccess.Abstract;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public List<CustomerDetailDto> GetCustomerDetail()
        {
            return _customerDal.GetCustomerDetailDtos().ToList();
        }
    }
}
