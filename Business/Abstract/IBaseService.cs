using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IBaseService<TEntity> where TEntity:class
    {
        // Temel iş operasyonlarını barından interface'i IBrandService,IColorService ve ICarService interfaceleri implement ediyor.
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
