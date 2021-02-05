using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface IBrandDal:IEntityRepository<Brand>
    {
        //EfBrandDal entityframework class'ımızın implement ettiği interface. EfBrandDal'a özel operasyonumuz olursa burada tanımlayacağız.

    }
}
