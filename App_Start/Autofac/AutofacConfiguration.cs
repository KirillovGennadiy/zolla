using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using AutoMapper;

namespace Test.App_Start.Autofac
{
    // Configurate autofac
    public class AutofacConfiguration
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            // Register automapper
            builder.RegisterAutoMapper(typeof(MvcApplication).Assembly);
            // Register context
            builder.RegisterModule(new AutofacDbContextModule());
            // Register repositories
            builder.RegisterModule(new AutofacRepositoryModule());
            // Register services
            builder.RegisterModule(new AutofacServicesModule());
            // Register Controllers
            builder.RegisterModule(new AutofacControllersModule());
            
            var container = builder.Build();
            // Set autofac dependency resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}