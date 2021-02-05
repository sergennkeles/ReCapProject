using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Business katmanındaki iş sınıflarımızın instance'ları
            CarManager carManager = new CarManager(new EfCarDal()) ;
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var color in colorManager.GetByColorId(2))
            {
                Console.WriteLine(color.ColorName);
            }
            foreach (var brand in brandManager.GetByBrandId(3))
            {
                Console.WriteLine(brand.BrandName);
            }
            foreach (var car in carManager.GetAllCars())
            {
                Console.WriteLine(car.ModelYear);
            }



   
        }
    }
}
