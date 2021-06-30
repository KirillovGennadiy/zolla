using Autofac;
using Test.DataAccess.Base;

namespace Test.App_Start.Autofac
{
    public class AutofacRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>)).InstancePerRequest();
        }
    }
}