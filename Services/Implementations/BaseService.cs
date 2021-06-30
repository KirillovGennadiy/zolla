using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Test.DataAccess.Base;
using Test.Services.Interfaces;
using Test.ViewModels;

namespace Test.Services.Implementations
{
    public class BaseService<TEntity, TViewModel> : IBaseService<TEntity, TViewModel>
        where TEntity: class, IEntity
        where TViewModel: class, IEntity, new()
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;
        protected readonly int _pageSize = 5;

        public BaseService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<TViewModel> CreateOrUpdate(int? id = null)
        {
            if (!id.HasValue)
            {
                return new TViewModel();
            }

            TEntity entity = await _repository.FirstOrDefaultAsync(id.Value);
            return _mapper.Map<TViewModel>(entity);
        }

        public virtual async Task CreateOrUpdate(TViewModel model)
        {
            TEntity entity = _mapper.Map<TEntity>(model);
            // update
            if (model.Id > 0)
            {
                await _repository.UpdateAsync(entity);
            } 
            // create
            else
            {
                _repository.Add(entity);
            }

            await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            TEntity entity = await _repository.FirstOrDefaultAsync(id);

            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task<IndexViewModel<TEntity>> GetGridAsync(int? page = null)
        {
            var model = new IndexViewModel<TEntity>();

            model.CurrentPage = page ?? 0;
            model.ItemsPerPage = _pageSize;
            model.Total = await _repository.GetQueryNoTracking().CountAsync();
            model.Items = await _repository.GetQueryNoTracking().OrderBy(x => x.Id).Skip(model.CurrentPage * _pageSize).Take(_pageSize).ToListAsync();;

            return model;
        }
    }
}