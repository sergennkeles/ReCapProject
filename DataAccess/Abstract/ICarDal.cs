using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ICarDal: IEntityRepository<Car>
    {
        //EfCarDal entityframework class'ımızın implement ettiği interface. EfCarDal'a özel operasyonumuz olursa burada tanımlayacağız.

    }
}
