using Entities.Concrete;
using Entities.DTOS;
using MyCore.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetByBrandId(int brandId);
        IDataResult<List<Car>> GetByPrice(decimal min,decimal max);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarDetailsBrandId(int brandId);
        IDataResult<CarDetailDto> GetCarDetailsCarId(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetailsColorId(int colorId);
        IDataResult<Car> GetById(int carId);
        IResult Add(Car car);

    }
}
