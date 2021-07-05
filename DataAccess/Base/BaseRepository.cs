using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Test.DataAccess.Base
{
    // Base Implementation of IRepository interface
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity: class, IEntity
    {
        // current dbcontext.Set<>
        private readonly DbSet<TEntity> _dbSet;
        // current dbContext
        private readonly TestDbContext _dbContext;
        // initialize repository. dbContext has been registered "AsSelf" in Autofac container and can be resolve in the constructor
        public BaseRepository(TestDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        // Represent sql query
        public virtual IQueryable<TEntity> GetQuery()
        {
            return _dbSet;
        }

        // This method executes a sql query and returns a collection, tracking is disabled. If the object has changed, EF will not know about it 
        public virtual IQueryable<TEntity> GetQueryNoTracking()
        {
            return _dbSet.AsNoTracking();
        }

        // Add object to context with state - added
        public virtual TEntity Add(TEntity entity)
        {
            return _dbSet.Add(entity);
        }

        // Mark object to delete with state deleted
        public virtual void Delete(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        // Get first or null object from DB
        public virtual async Task<TEntity> FirstOrDefaultAsync(int key)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == key);
        }

        // Provide objects into db
        public virtual async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        // Update and return changed object
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var updateEntity = await _dbSet.SingleAsync(x => x.Id == entity.Id);
            _dbContext.Entry(updateEntity).CurrentValues.SetValues(entity);

            return updateEntity;
        }

        // Freeing unmanaged memory, autofac call this method automatically when lifetimescope is over
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                    _dbContext.Dispose();
            }
        }

    }
}