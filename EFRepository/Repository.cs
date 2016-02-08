using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace EFRepository
{
    public class Repository : IRepository
    {
        protected DbContext Context;

        public Repository(DbContext context,
                            bool autoDetectableChangesEnabled = false,
                            bool proxyCreationEnabled = false)
        {
            this.Context = context;
            this.Context.Configuration.AutoDetectChangesEnabled = autoDetectableChangesEnabled;
            this.Context.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
        }

        public TEntity Create<TEntity>(TEntity newEntity) where TEntity : class
        {
            TEntity Result;

            try
            {
                Result = Context.Set<TEntity>().Add(newEntity);
                TrySaveChanges();
            }catch(Exception e)
            {
                throw (e);
            }

            return Result;
        }

        protected virtual int TrySaveChanges()
        {
            return Context.SaveChanges();
        }

        public bool Delete<TEntity>(TEntity deleteEntity) where TEntity : class
        {
            bool Result = false;

            try
            {
                Context.Set<TEntity>().Attach(deleteEntity);
                Context.Set<TEntity>().Remove(deleteEntity);
                Result = TrySaveChanges() > 0;

            }
            catch (Exception e)
            {
                throw (e);
            }

            return Result;
        }

        public void Dispose()
        {
            if(Context != null)
            {
                Context.Dispose();
            }
        }

        public TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            TEntity Result = null;

            try
            {
                Result = Context.Set<TEntity>().FirstOrDefault(criteria);
            }catch(Exception e)
            {
                throw (e);
            }

            return Result;
        }

        public IEnumerable<TEntity> FindEntitySet<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            List<TEntity> Result = null;

            try
            {
                Result = Context.Set<TEntity>().Where(criteria).ToList();
             }
            catch (Exception e)
            {
                throw (e);
            }

            return Result;
        }

        public bool Update<TEntity>(TEntity modifiedEntity) where TEntity : class
        {
            bool Result;

            try
            {
                Context.Set<TEntity>().Attach(modifiedEntity);
                Context.Entry<TEntity>(modifiedEntity).State = System.Data.EntityState.Modified;
                Result = TrySaveChanges() > 0;
           
            }
            catch (Exception e)
            {
                throw (e);
            }

            return Result;
        }
    }
}
