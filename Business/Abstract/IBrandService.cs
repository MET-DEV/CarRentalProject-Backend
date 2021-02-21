using Entities.Concrete;
using MyCore.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        Brand GetById(int brandId);
        IResult Add(Brand brand); 
    }
}
