using Entities.Concrete;
using Entities.DTOS;
using MyCore.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        List<CustomerDetailDto> GetCustomerDetail();
        IResult Add(Customer customer);
    }
}
