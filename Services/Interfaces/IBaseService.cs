using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Test.ViewModels;

namespace Test.Services.Interfaces
{
    public interface IBaseService<TEntity, TViewModel> 
        where TEntity: class
    {
        Task<TViewModel> CreateOrUpdate(int? id = null);
        Task CreateOrUpdate(TViewModel model);
        Task Delete(int id);
        Task<IndexViewModel<TEntity>> GetGridAsync(int? page = null);
    }
}