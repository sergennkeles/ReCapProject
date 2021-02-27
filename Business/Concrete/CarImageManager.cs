using Business.Abstract;
using Business.Constants;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public IResult Add(CarImage entity)
        {
            IResult result = BusinessRules.Run(CheckImageCount(entity.CarId));

            if (result!=null)
            {
                return result;
            }
            _carImageDal.Add(entity);
            return new SuccessResult(Messages.AddedCarImage);
        }

        public IResult Delete(CarImage entity)
        {
            _carImageDal.Delete(entity);
            return new SuccessResult(Messages.DeletedCarImage);
        }

        public IDataResult<List<CarImage>> GetAll(int carId)
        {
            var result = _carImageDal.GetAll(x => x.CarId == carId);
           if( result.Count == 0)
                result.Add(new CarImage { CarId = carId, ImagePath = "DefaultImage.jpg" });
                        
            return new SuccessDataResult<List<CarImage>>(result,Messages.ListedCarImages);
        }

        public IDataResult<CarImage> GetById(int Id)
        {
          return new SuccessDataResult<CarImage>( _carImageDal.GetById(x => x.Id == Id),Messages.GetByIdCarImage);
        }

        public IResult Update(CarImage entity)
        {
            var result = _carImageDal.GetById(c => c.Id == entity.Id);
            if (result!=null)
            {
                result.ImagePath = entity.ImagePath;
                result.Date = DateTime.Now;
                _carImageDal.Update(entity);
                return new SuccessResult(Messages.UpdatedCarImage);
            }
            return new ErrorResult(Messages.ErrorUpdateCarImage);
        }
    
    private IResult CheckImageCount(int carId)
        {
            var result = _carImageDal.GetAll(x => x.CarId == carId).Count;
            if (result<5)
            {
                return new SuccessResult();

            }
            return new ErrorResult(Messages.MaxImgUpload);

        }
    }
       
}
