using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.DataAccess.Base;
using Test.Models;
using Test.Services.Interfaces;
using Test.ViewModels;

namespace Test.Services.Implementations
{
    public class ClientService : BaseService<Client, ClientViewModel>, IClientService
    {
        public ClientService (
            IRepository<Client> repository,
            IMapper mapper
            ) : base(repository, mapper)
        { }
    }
}