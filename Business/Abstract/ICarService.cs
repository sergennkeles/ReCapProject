using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public interface ICarService
    {
        List<Car> GetAllCars();
        List<Car> GetByIdCar(int id);
        List<Brand> GetCarsByBrandId(int id);
        List<Color> GetCarsByColorId(int id);


    }
}
