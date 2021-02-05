using DataAccess.Abstract;
using Entities.Concrete;
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

        public InMemoryDal()
        {
            _cars = new List<Car> { 
                new Car { Id = 1, BrandId = 2, ColorId = 2, ModelYear = "2019", DailyPrice = 199, Description = "Kiralık" },
                new Car { Id = 2, BrandId = 3, ColorId = 1, ModelYear = "2018", DailyPrice = 299, Description = "Kiralık" }};
        }
        public void Add(Car entity)
        {
            _cars.Add(entity);
        }

        public void Delete(Car entity)
        {
            _cars.Remove(entity);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public void GetById(Expression<Func<Car, bool>> filter)
        {
           
        }

        public void Update(Car entity)
        {
            Car carUpdate = _cars.SingleOrDefault(c => c.Id == entity.Id);
            carUpdate.BrandId = entity.BrandId;
            carUpdate.ColorId = entity.ColorId;
            carUpdate.ModelYear = entity.ModelYear;
            carUpdate.DailyPrice = entity.DailyPrice;
            carUpdate.Description = entity.Description;
        }
    }
}
