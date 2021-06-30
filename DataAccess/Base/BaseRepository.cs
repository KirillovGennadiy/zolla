using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Test.DataAccess.Base
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity: class, IEntity
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly TestDbContext _dbContext;
        public BaseRepository(TestDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        public virtual IQueryable<TEntity> GetQuery()
        {
            return _dbSet;
        }

        public virtual IQueryable<TEntity> GetQueryNoTracking()
        {
            return _dbSet.AsNoTracking();
        }

        public virtual TEntity Add(TEntity entity)
        {
            return _dbSet.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(int key)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == key);
        }

        public virtual async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<TEntity> SingleAsync(int key)
        {
            return await _dbSet.AsNoTracking().SingleAsync(x => x.Id == key);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var updateEntity = await _dbSet.SingleAsync(x => x.Id == entity.Id);
            _dbContext.Entry(updateEntity).CurrentValues.SetValues(entity);

            return updateEntity;
        }

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