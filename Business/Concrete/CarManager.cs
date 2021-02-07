using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        //EfCarDal dan gelen verilerin iş sınıfı
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car entity)
        {
            if (entity.DailyPrice<=0)
            {
                Console.WriteLine("Araba fiyatı sıfırdan büyük olmalıdır.");
            }
            else
            {
               _carDal.Add(entity);
               
            }
        }

        public void Delete(Car entity)
        {
            _carDal.Delete(entity);
        }

        public List<Car> GetAllCars(Expression<Func<Car, bool>> filter = null)
        {
            return _carDal.GetAll();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            return _carDal.GetAllCarDetail();
        }

        public void Update(Car entity)
        {
            _carDal.Update(entity);
        }
    }
}
