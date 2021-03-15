using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryDal() // InMemory olarak verilerimizi ekledik.
        {
            _cars = new List<Car> { 
                new Car { Id = 1, BrandId = 2, ColorId = 2, ModelYear = "2019", DailyPrice = 199, Description = "Kiralık" },
                new Car { Id = 2, BrandId = 3, ColorId = 1, ModelYear = "2018", DailyPrice = 299, Description = "Kiralık" }};
        }
        public void Add(Car entity)
        {
            _cars.Add(entity);//ekleme işlemleri
        }

        public void Delete(Car entity)
        {
            _cars.Remove(entity);//silme işlemleri
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars; // Tüm araçları listeleme işlemleri
        }

   

        public List<CarDetailDto> GetAllCarDetail(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetAllCarDetail()
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity) // Güncelleme işlemleri
        {
            Car carUpdate = _cars.SingleOrDefault(c => c.Id == entity.Id);
            carUpdate.BrandId = entity.BrandId;
            carUpdate.ColorId = entity.ColorId;
            carUpdate.ModelYear = entity.ModelYear;
            carUpdate.DailyPrice = entity.DailyPrice;
            carUpdate.Description = entity.Description;
        }

        public CarDetailDto GetCarDetail(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
