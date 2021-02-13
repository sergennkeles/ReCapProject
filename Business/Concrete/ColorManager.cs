using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService

    {
        //EfColorDal gelen verilerin iş sınıfı
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal) 
        {
            
            _colorDal = colorDal;
        }

        public IResult Add(Color entity)
        {
            _colorDal.Add(entity);
            return new SuccessResult(Messages.AddedColor);
        }

        public IResult Delete(Color entity)
        {
            _colorDal.Delete(entity);
            return new SuccessResult(Messages.DeletedColor);
        }

        public IDataResult<List<Color>> GetAllColors()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<List<Color>> GetByColorId(int id)
        {

            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(x=>x.ColorId==id));//tekrar bak
        }

        public IResult Update(Color entity)
        {
            _colorDal.Update(entity);
            return new SuccessResult(Messages.UpdatedColor);
        }
    }
}
