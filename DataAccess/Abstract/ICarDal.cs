using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ICarDal: IEntityRepository<Car>
    {
        //EfCarDal entityframework class'ımızın implement ettiği interface. EfCarDal'a özel operasyonumuz olursa burada tanımlayacağız.
        List<CarDetailDto> GetAllCarDetail(Expression<Func<Car, bool>> filter = null);
        CarDetailDto GetCarDetail(int carId);
    }
}
