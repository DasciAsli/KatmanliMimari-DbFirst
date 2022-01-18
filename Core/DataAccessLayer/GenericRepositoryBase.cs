using Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccessLayer
{
    public class GenericRepositoryBase<TContext, TEntity> : IRepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext db = new TContext())
            {
                var model = db.Entry(entity);
                model.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext db = new TContext())
            {
                var model = db.Entry(entity);
                model.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            TContext db = new TContext();
            return db.Set<TEntity>().SingleOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            TContext db = new TContext();
            return filter == null ?
                db.Set<TEntity>().ToList():
                db.Set<TEntity>().Where(filter).ToList();
        }

        public TEntity GetDetail(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext db= new TContext())
            {
                return db.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext db = new TContext())
            {
                var model = db.Entry(entity);
                model.State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
