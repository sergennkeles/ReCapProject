using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        // Car entity için Veritabanı işlemleri
        public CarDetailDto GetCarDetail(int carId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from car in context.Cars.Where(x=>x.Id==carId)
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join col in context.Colors
                             on car.ColorId equals col.ColorId
                             orderby (car.Id)
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 BrandName = brand.BrandName,
                                 ColorName = col.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 Description = car.Description
                             };
                return result.SingleOrDefault();
            }
        }

        public List<CarDetailDto> GetAllCarDetail(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context=new RentACarContext())
            {
                var result = from car in filter == null ? context.Cars : context.Cars.Where(filter)
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join col in context.Colors
                             on car.ColorId equals col.ColorId
                             orderby (car.Id)
                             select new CarDetailDto
                             {
                                 Id=car.Id,
                                 BrandName=brand.BrandName,
                                 ColorName=col.ColorName,
                                 DailyPrice=car.DailyPrice,
                                 ModelYear=car.ModelYear,
                                 Description=car.Description
                             };
                return result.ToList();
            }
        }
    }
}
