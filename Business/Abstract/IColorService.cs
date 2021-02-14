using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService:IBaseService<Color>
    {
        IDataResult<Color> GetByColorId(int id);//ColorManager iş sınıfına özel operasyonumuz.
        IDataResult<List<Color>> GetAllColors();
    }
}
