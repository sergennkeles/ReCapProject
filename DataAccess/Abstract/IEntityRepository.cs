using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        // generic yapıdaki temel interface ve temel operasyonlar. Bu interface'i ICarDal, IColorDal ve IBrandDal 
        //interfaceleri implement ediyor.
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);

        TEntity GetById(Expression<Func<TEntity, bool>> filter);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
