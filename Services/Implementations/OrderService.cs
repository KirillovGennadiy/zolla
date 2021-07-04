using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Test.DataAccess.Base;
using Test.Models;
using Test.Services.Interfaces;
using Test.ViewModels;

namespace Test.Services.Implementations
{
    public class OrderService : BaseService<Order, OrderViewModel>, IOrderService
    {
        public OrderService(
            IRepository<Order> repository,
            IMapper mapper
            ) : base(repository, mapper)
        { }

        public async Task<IndexViewModel<Order>> GetByReferenceIdAsync(int id, int? page = null)
        {
            var model = new IndexViewModel<Order>();

            model.ParentId = id;
            model.CurrentPage = page ?? 0;
            model.ItemsPerPage = _pageSize;
            model.Total = await _repository.GetQueryNoTracking().Where(x => x.ClientId == id).CountAsync();
            model.Items = await _repository.GetQueryNoTracking().Where(x => x.ClientId == id).OrderBy(x => x.Id).Skip(model.CurrentPage * _pageSize).Take(_pageSize).ToListAsync();

            return model;
        }

        public async Task<OrderViewModel> CreateOrUpdateByReferenceIdAsync(int referenceId, int? id = null)
        {
            if (!id.HasValue)
            {
                return new OrderViewModel { ClientId = referenceId };
            }

            Order entity = await _repository.FirstOrDefaultAsync(id.Value);
            return _mapper.Map<OrderViewModel>(entity);
        }

    }
}