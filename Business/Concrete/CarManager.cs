using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [ValidationAspect(typeof(CarValidator))] //Validasyon işlemi
        public IResult Add(Car entity)
        {

            _carDal.Add(entity);
            return new SuccessResult(Messages.AddedCar);


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

        public IDataResult<Car> GetByCarId(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.GetById(c => c.Id == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()

        {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetail());
        }

        public IResult Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult(Messages.UpdatedCar);
        }
        public IDataResult<List<Car>> GetAllCarsIfNotRented()
        {
            var result = new SuccessDataResult<List<Car>>(_carDal.GetAll(c => !c.Rentals.Any(r => r.ReturnDate == null)));
            return result;
        }
    }
}
