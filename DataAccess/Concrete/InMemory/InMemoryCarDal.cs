using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using MyCore.DataAccess;
using System.Linq.Expressions;
using System.Text;
using Entities.DTOS;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { new Car {Id=1,Name="Toyota",ColorId=1,BrandId=2,DailyPrice=2000,Description="Car",ModelYear=1999 },
                new Car {Id=2,Name="Peugeout",ColorId=2,BrandId=3,DailyPrice=12000,Description="Car",ModelYear=2003 },
                new Car {Id=3,Name="McLaren",ColorId=1,BrandId=2,DailyPrice=6000,Description="Car",ModelYear=2011 },
                new Car {Id=4,Name="Ford",ColorId=1,BrandId=2,DailyPrice=3000,Description="Car",ModelYear=2020 },
                new Car {Id=5,Name="Porche",ColorId=3,BrandId=1,DailyPrice=4000,Description="Car",ModelYear=2021 }


            };
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var deletetocar = _cars.SingleOrDefault(c=>c.Id==car.Id);
            _cars.Remove(deletetocar);
        }

        public List<Car> Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var updateToCar = _cars.SingleOrDefault(c=>c.Id==car.Id);
            updateToCar.Id = car.Id;
            updateToCar.Name = car.Name;
            updateToCar.ModelYear = car.ModelYear;
            updateToCar.Description = car.Description;
            updateToCar.DailyPrice = car.DailyPrice;
            updateToCar.BrandId = car.BrandId;
        }

        Car IEntityRepository<Car>.Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
