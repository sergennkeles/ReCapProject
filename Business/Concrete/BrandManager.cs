using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        // EfBrandDal'dan gelen verilerin iş sınıfı
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void Add(Brand entity)
        {
            if (entity.BrandName.Length<=2)
            {
                Console.WriteLine("Araba adı 2 karakterden az olamaz.");
            }
            else
            {
                _brandDal.Add(entity);
            }

        }

        public void Delete(Brand entity)
        {
            _brandDal.Delete(entity);
        }

        public List<Brand> GetByBrandId(int id)
        {
            return _brandDal.GetAll(x => x.BrandId == id);
        }

        public void Update(Brand entity)
        {
            _brandDal.Update(entity);
        }
    }
}
