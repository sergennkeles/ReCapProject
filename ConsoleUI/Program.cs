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
            //carManager.Update(new Car { Id=})
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.Id + "/"+ car.BrandName+"/"+car.ColorName+"/"+car.ModelYear+"/"+car.Description );
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetByColorId(2))
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
          
            foreach (var brand in brandManager.GetByBrandId(1))
            {
                Console.WriteLine(brand.BrandName);
            }
        }
    }
}
