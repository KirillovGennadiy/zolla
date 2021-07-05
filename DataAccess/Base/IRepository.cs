using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DataAccess.Base
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity: class
    {
        IQueryable<TEntity> GetQuery();
        IQueryable<TEntity> GetQueryNoTracking();
        Task<TEntity> FirstOrDefaultAsync(int key);
        TEntity Add(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        void Delete(TEntity entity);
        Task SaveChangesAsync();
    }
}
