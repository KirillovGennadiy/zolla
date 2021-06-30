using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using AutoMapper;

namespace Test.App_Start.Autofac
{
    public class AutofacConfiguration
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterAutoMapper(typeof(MvcApplication).Assembly);
            builder.RegisterModule(new AutofacControllersModule());
            builder.RegisterModule(new AutofacDbContextModule());
            builder.RegisterModule(new AutofacRepositoryModule());
            builder.RegisterModule(new AutofacServicesModule());
            builder.RegisterModule(new AutofacControllersModule());
            
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}