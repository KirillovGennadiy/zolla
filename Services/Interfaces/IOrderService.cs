using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models;
using Test.ViewModels;

namespace Test.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IndexViewModel<Order>> GetOrdersByReferenceIdAsync(int id, int? page = null);
        Task<OrderViewModel> CreateOrUpdateByReferenceId(int referenceId, int? id = null);
    }
}
