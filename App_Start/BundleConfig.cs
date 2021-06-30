using System.Web;
using System.Web.Optimization;

namespace Test
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/bootstrap.min.js",
                    "~/Scripts/popper.min.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                    "~/Scripts/script.js"));
            
            
            bundles.Add(new ScriptBundle("~/bundles/ajax").Include(
                    "~/Scripts/jquery.unobtrusive-ajax.min.js"));
            
            
            bundles.Add(new ScriptBundle("~/bundles/datetimepicker").Include(
                    "~/Scripts/moment.min.js",
                    "~/Scripts/datetimepicker/bootstrap-datetimepicker.min.js",
                    "~/Scripts/datetimepicker/bootstrap-datetimepicker.ru.js"
                    ));


            bundles.Add(new StyleBundle("~/Content/datetimepicker").Include(
                      "~/Content/font-awesome.min.css",
                      "~/Content/bootstrap-datetimepicker.min.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css"));
        }
    }
}
