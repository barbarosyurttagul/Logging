using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Msb.Core.DataAccess
{
    public interface IEntityRepository<TEntity> where TEntity: class, IEntity
    {
        TEntity Insert(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);

        List<TEntity> GetAll();

        List<TEntity> GetList(Expression<Func<TEntity, bool>> filter);

        TEntity Get(Expression<Func<TEntity, bool>> filter);
    }
}
