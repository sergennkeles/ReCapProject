using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
          // BrandTest();
            // ColorTest();
           CarManagerTest();
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
           // carManager.Update(new Car {Id=2003, BrandId = 4, ColorId = 4, DailyPrice = 150, ModelYear = "2009", Description = "Kiralık" });
            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {

                    Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-13} | {3,-13} | {4,-13} | {5,-13}",
                    car.Id, car.BrandName, car.ColorName, car.DailyPrice + " TL", car.ModelYear, car.Description));

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
           
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result = colorManager.GetByColorId(2);

            foreach (var color in result.Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.Add(new Brand { BrandName = "Fiat" });

            if (result.Success==true)
            {
                Console.WriteLine(  result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
           
        }
    }
}
