using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using MyCore.Utilities.Business;
using MyCore.Utilities.Results;
using System;
using System.Collections.Generic;
using MyCore.Utilities.FileHelper;
using System.Linq;
using System.Text;
using Entities.DTOS;
using Business.Constants;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile formFile, CarImage carImage)
        {

            IResult result = BusinessRules.Run(CheckImageLimit(carImage.CarId));

            if (result != null)
            {
                return new ErrorResult();
            }
            var pathResult = FileHelper.Add(formFile);
            carImage.ImagePath = pathResult.Message;
            carImage.Date = DateTime.Now;
            
            _carImageDal.Add(carImage);
            return new SuccessDataResult("Eklendi");

        }

        public IResult Addd(IFormFile File, CarImage carImage)
        {
            throw new NotImplementedException();
        }


        //public IResult Addd(IFormFile File, CarImage carImage)
        //{




        //    carImage.ImagePath = FileHelper.Add(File);
        //    carImage.Date = DateTime.Now;
        //    _carImageDal.Add(carImage);
        //    return new SuccessDataResult();
        //}

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessDataResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>> (_carImageDal.GetAll());

        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarId == id));
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessDataResult();
        }
        private IResult CheckImageLimit(int carId)
        {
            var context = _carImageDal.GetAll(c=>c.CarId==carId).Count;
            if (context>5)
            {
                return new ErrorResult();
            }
            return new SuccessDataResult();
        }
    }
}
