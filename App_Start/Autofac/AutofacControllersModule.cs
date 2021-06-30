using Autofac;
using Autofac.Integration.Mvc;
using Test.Controllers;

namespace Test.App_Start.Autofac
{
    public class AutofacControllersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(ClientController).Assembly);
        }
    }
}