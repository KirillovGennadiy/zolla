using System.Web.Mvc;
using Test.Models;
using Test.Services.Implementations;
using Test.Services.Interfaces;
using Test.ViewModels;

namespace Test.Controllers
{
    // inheriting from base controller. Set Client as TEntity, ClientViewModel as TEntityViewModel
    public class ClientController : BaseController<Client, ClientViewModel>
    {
        public ClientController(
            IBaseService<Client, ClientViewModel> service // autofac resolve this as BaseService<Client, ClientViewModel> and create repository instance
            ) : base(service) // call the constructor of base service
        { }
    }

}