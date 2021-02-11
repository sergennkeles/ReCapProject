using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        //EfCarDal dan gelen verilerin iş sınıfı
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IResult Add(Car entity)
        {
            if (entity.DailyPrice<=0)
            {
                return new ErrorDataResult<List<Car>>(Messages.UpdatedCar);

            }
            else
            {
                _carDal.Add(entity);
                return new SuccessResult(Messages.AddedCar);

            }
        }

        public IResult Delete(Car entity)
        {
             _carDal.Delete(entity);
            return new SuccessResult(Messages.DeletedCar);
        }

        public IDataResult<List<Car>> GetAllCars(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()

        {
            if (DateTime.Now.Hour==20)
            {
                return new ErrorDataResult<List<CarDetailsDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetAllCarDetail());
        }

        public IResult Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult(Messages.UpdatedCar);
        }
    }
}
