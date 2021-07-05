using Autofac;
using Test.DataAccess.Base;
using Test.Models;
using Test.Services.Implementations;
using Test.Services.Interfaces;
using Test.ViewModels;

namespace Test.App_Start.Autofac
{
    public class AutofacServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(BaseService<,>)).As(typeof(IBaseService<,>)).InstancePerRequest();

            builder.RegisterType<ClientService>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<OrderService>().AsImplementedInterfaces().InstancePerRequest();
        }
    }
}