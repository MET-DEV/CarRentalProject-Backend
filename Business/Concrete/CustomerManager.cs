using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using MyCore.Aspects.Autofac.Validation;
using MyCore.Utilities.Results;
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
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessDataResult();
        }

        public List<CustomerDetailDto> GetCustomerDetail()
        {
            return _customerDal.GetCustomerDetailDtos().ToList();
        }
    }
}
