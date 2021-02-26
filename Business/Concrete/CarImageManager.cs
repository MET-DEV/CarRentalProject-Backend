using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using MyCore.Utilities.Business;
using MyCore.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckImageLimit(carImage.CarId));
            if (result!=null)
            {
                return result;
            }
            _carImageDal.Add(carImage);
            return new SuccessDataResult();
        }

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
