using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IColorDal : IEntityRepository<Color>
    {
        //EfColorDal entityframework class'ımızın implement ettiği interface. EfColorDal'a özel operasyonumuz olursa burada tanımlayacağız.
    }
}
