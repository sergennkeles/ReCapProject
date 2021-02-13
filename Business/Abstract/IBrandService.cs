using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public  interface IBrandService:IBaseService<Brand>
    {
       IDataResult<List<Brand>> GetByBrandId(int id); //BrandManager iş sınıfına özel operasyonumuz.
        IDataResult<List<Brand>> GetAllBrands();

    }
}
