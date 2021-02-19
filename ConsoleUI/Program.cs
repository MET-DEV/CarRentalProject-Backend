using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            RentalDetailTest();
            //CustomerDetailTest();
            //CarTest();
            //BrandTest();
        }

        private static void RentalDetailTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalDetails();
            foreach (var rentalDetail in result.Data)
            {
                Console.WriteLine(rentalDetail.CarName + " / " + rentalDetail.CustomerName);
            }
            Console.WriteLine(result.Message);
        }

        private static void CustomerDetailTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            foreach (var detail in customerManager.GetCustomerDetail())
            {
                Console.WriteLine(detail.CustomerName + " / " + detail.CustomerLastName + "  / " + detail.CustomerMailAdress);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void CarTest()
        {
            
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName+" / "+car.BrandName);
                }
                
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
