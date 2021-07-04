using System.Web;
using System.Web.Optimization;

namespace Test
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            Scripts(bundles);
            Styles(bundles);
        }

        public static void Scripts(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/popper.min.js",
                    "~/Scripts/bootstrap.min.js"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/ajax").Include(
                    "~/Scripts/jquery.unobtrusive-ajax.min.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/mask").Include(
                    "~/Scripts/jquery.mask.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/datetimepicker").Include(
                    "~/Scripts/moment.min.js",
                    "~/Scripts/moment-with-locales.min.js",
                    "~/Scripts/datetimepicker/bootstrap-datetimepicker.min.js"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                    "~/Scripts/components/functions.js",
                    "~/Scripts/components/form.js",
                    "~/Scripts/components/modal.js"
                    ));

        }

        public static void Styles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Content/datetimepicker").Include(
                      "~/Content/font-awesome.min.css",
                      "~/Content/bootstrap-datetimepicker.min.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css"));
        }
    }
}
