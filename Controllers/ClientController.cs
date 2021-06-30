using System.Web.Mvc;
using Test.Models;
using Test.Services.Implementations;
using Test.Services.Interfaces;
using Test.ViewModels;

namespace Test.Controllers
{
    public class ClientController : BaseController<Client, ClientViewModel>
    {
        public ClientController(
            IBaseService<Client, ClientViewModel> service
            ) : base(service)
        { }
    }

}