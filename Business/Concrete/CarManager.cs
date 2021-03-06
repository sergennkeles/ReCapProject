﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
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
using System.Threading;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        //EfCarDal dan gelen verilerin iş sınıfı
        ICarDal _carDal;
        ICarImageService _carImageService;

        public CarManager(ICarDal carDal,ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }

        [ValidationAspect(typeof(CarValidator))] //Validasyon işlemi
       [SecuredOperation("car.add,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        [LogAspect(typeof(FileLogger))]

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
       
        [PerformanceAspect(1)]
        [CacheAspect]
        public IDataResult<List<Car>> GetAllCars(Expression<Func<Car, bool>> filter = null)
        {
          //  Thread.Sleep(5000); //PerformanceAspect'i test etmek için
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<CarDetailDto> GetByCarId(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailsById(c => c.Id == carId));
        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()

        {
            //if (DateTime.Now.Hour == 20)
            //{
            //    return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetail());
        }
        [CacheRemoveAspect("ICarService.Get")]
        [LogAspect(typeof(FileLogger))]

        public IResult Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult(Messages.UpdatedCar);
        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetAllCarsIfNotRented()
        {
            var result = new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetail(c => !c.Rentals.Any(r => r.ReturnDate == null)));
            return result;
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            _carDal.Update(car);
          //  _carDal.Add(car);
            return new SuccessResult(Messages.TransactionExecute);
        }

        public IDataResult<List<CarDetailDto>> GetByBrandId(int brandId)
        {
            List<CarDetailDto> carDetails = _carDal.GetAllCarDetail(p => p.BrandId == brandId);
            if (carDetails == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.GetErrorCarMessage);
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(carDetails);
            }

        }

        public IDataResult<List<CarDetailDto>> GetByColorId(int colorId)
        {
            List<CarDetailDto> carDetails = _carDal.GetAllCarDetail(p => p.ColorId == colorId);
            if (carDetails == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.GetErrorCarMessage);
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(carDetails);
            }
        }

        public IDataResult<CarDetailImageDto> GetCarDetailWithİmage(int carId)
        {
            var result = _carDal.GetCarDetail(carId);
            var imageResult = _carImageService.GetAll(carId);

            if (result == null || imageResult.Success == false)
            {
                return new ErrorDataResult<CarDetailImageDto>(Messages.GetErrorCarMessage);
            }

            var carDetailImageDto = new CarDetailImageDto
            {
                Car = result,
                CarImages = imageResult.Data
            };

            return new SuccessDataResult<CarDetailImageDto>(carDetailImageDto, Messages.GetSuccessCarMessage);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailByBrandIdAndColorId(int brandId, int colorId)
        {
            List<CarDetailDto> carDetails = _carDal.GetAllCarDetail(p => p.BrandId == brandId && p.ColorId == colorId);
            if (carDetails == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.GetErrorCarMessage);
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(carDetails, Messages.GetErrorCarMessage);
            }
        }
    }
}
