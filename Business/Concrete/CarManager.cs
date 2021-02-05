using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandDal _brandDal;
        IColorDal _colorDal;

        public CarManager(ICarDal carDal,IBrandDal brandDal, IColorDal colorDal)
        {
            _carDal = carDal;
            _brandDal = brandDal;
            _colorDal = colorDal;
        }
        public List<Car> GetAllCars()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetByIdCar(int id)
        {
           return  _carDal.GetAll(c=>c.Id==id);
        }

        public List<Brand> GetCarsByBrandId(int id)
        {
            return _brandDal.GetAll(c => c.BrandId == id);

        }

        public List<Color> GetCarsByColorId(int id)
        {
            return _colorDal.GetAll(c => c.ColorId == id);

        }

    }
}
