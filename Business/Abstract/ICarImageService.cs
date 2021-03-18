using Entities.Concrete;
using Entities.DTOS;
using Microsoft.AspNetCore.Http;
using MyCore.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
        IResult Add(IFormFile file, CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult Update(CarImage carImage);
        IResult Addd(IFormFile File, CarImage carImage);
    }
}
