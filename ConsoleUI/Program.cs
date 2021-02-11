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
            //BrandTest();
            // ColorTest();
            CarManagerTest();
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 4, ColorId = 2, DailyPrice = -450, ModelYear = "2008", Description = "Kiralık" });
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
            var result = brandManager.GetByBrandId(1);
            foreach (var brand in result.Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }
    }
}
