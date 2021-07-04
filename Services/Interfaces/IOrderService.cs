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
        Task<IndexViewModel<Order>> GetByReferenceIdAsync(int id, int? page = null);
        Task<OrderViewModel> CreateOrUpdateByReferenceIdAsync(int referenceId, int? id = null);
    }
}
