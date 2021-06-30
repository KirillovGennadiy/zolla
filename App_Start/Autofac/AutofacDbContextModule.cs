using Autofac;

namespace Test.App_Start.Autofac
{
    public class AutofacDbContextModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataAccess.TestDbContext>().AsSelf().InstancePerRequest();
        }
    }
}