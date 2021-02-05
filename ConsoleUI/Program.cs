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

            CarManager carManager = new CarManager(new EfCarDal(), new EfBrandDal(), new EfColorDal()) ;

            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.BrandName);
            }
        }
    }
}
