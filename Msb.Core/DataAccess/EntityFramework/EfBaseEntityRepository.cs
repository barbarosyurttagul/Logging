using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Msb.Core.DataAccess.EntityFramework
{
    //Template
    public abstract class EfBaseEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity
        where TContext: DbContext, new()
    {
        public virtual void DeleteContext(TEntity entity, TContext context)
        {
            DbEntityEntry entry = context.Entry(entity);
            entry.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                DeleteContext(entity, context);                
            }
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public virtual List<TEntity> GetAll()
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public virtual TEntity Insert(TEntity entity)
        {
            using (var context = new TContext())
            {
               
                DbEntityEntry entry = context.Entry(entity);
                entry.State = EntityState.Added;
                context.SaveChanges();
                return (TEntity)entry.Entity;
            }
        }

        public virtual TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                DbEntityEntry entry = context.Entry(entity);
                entry.State = EntityState.Modified;
                context.SaveChanges();
                return (TEntity)entry.Entity;
            }
        }
    }
}
