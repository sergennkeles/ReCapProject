using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
  public interface ICarService:IBaseService<Car>
    {
        IDataResult<List<Car>> GetAllCars(Expression<Func<Car,bool>> filter=null);//CarManager iş sınıfına özel operasyonumuz.
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetAllCarsIfNotRented();
        IDataResult<CarDetailDto> GetByCarId(int carId);
        IDataResult<List<CarDetailDto>> GetByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetByColorId(int colorId);
        IDataResult<CarDetailImageDto> GetCarDetailWithİmage(int carId);
        IDataResult<List<CarDetailDto>> GetCarsDetailByBrandIdAndColorId(int brandId, int colorId);


        IResult AddTransactionalTest(Car car);
    }
}
