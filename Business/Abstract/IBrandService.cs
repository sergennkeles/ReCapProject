using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public  interface IBrandService:IBaseService<Brand>
    {
        List<Brand> GetByBrandId(int id); //BrandManager iş sınıfına özel operasyonumuz.
    }
}
