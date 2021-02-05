using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
  public interface ICarService:IBaseService<Car>
    {
        List<Car> GetAllCars(Expression<Func<Car,bool>> filter=null);//CarManager iş sınıfına özel operasyonumuz.


    }
}
