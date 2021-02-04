using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryDal : ICarDal
    {
        public void Add(Car entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
