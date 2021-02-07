using Business.Abstract;
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

        public void Add(Color entity)
        {
            _colorDal.Add(entity);
        }

        public void Delete(Color entity)
        {
            _colorDal.Delete(entity);
        }

        public List<Color> GetByColorId(int id)
        {
            
            return _colorDal.GetAll(x=>x.ColorId==id);//tekrar bak
        }

        public void Update(Color entity)
        {
            _colorDal.Update(entity);
        }
    }
}
