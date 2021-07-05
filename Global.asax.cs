using AutoMapper;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Test.App_Start.Autofac;
using Test.App_Start.Automapper;
using Test.DataAccess;

namespace Test
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacConfiguration.Configure();

            // Initialize test data
            using (var context = new TestDbContext())
            {
                DbInit.Initialize(context);
            }
        }
    }
}
