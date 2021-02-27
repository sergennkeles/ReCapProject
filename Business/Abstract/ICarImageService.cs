using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarImageService :IBaseService<CarImage>
    {
        IDataResult<List<CarImage>> GetAll(int carId);
        IDataResult<CarImage> GetById(int Id);
    }
}
