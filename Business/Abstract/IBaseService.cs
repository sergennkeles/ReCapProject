using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IBaseService<TEntity> where TEntity:class
    {
        // Temel iş operasyonlarını barından interface'i IBrandService,IColorService ve ICarService interfaceleri implement ediyor.
        IResult Add(TEntity entity);
        IResult Update(TEntity entity);
        IResult Delete(TEntity entity);
    }
}
