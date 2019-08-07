using System.Web;
using System.Web.Optimization;

namespace Arduino
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.validate.min.js",
                    "~/Scripts/jquery.validate.unobtrusive.min.js"
                    ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));


            bundles.Add(new StyleBundle("~/Content/css").Include(                      
                      "~/Vendor/plugins/datatables/jquery.dataTables.min.css",                      
                      "~/Vendor/dist/js/plugins/font-awesome/css/font-awesome.min.css",
                      "~/Vendor/dist/css/adminlte.min.css",     
                      "~/Content/site.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                //"~/Vendor/plugins/jquery/jquery.min.js",
                    "~/Vendor/plugins/bootstrap/js/bootstrap.bundle.min.js",
                    "~/Vendor/dist/js/adminlte.min.js",
                    "~/Vendor/dist/js/demo.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                //"~/Scripts/angular.js",E:\Working\AtidWebAPI\AtidWebAPI\Vendor\plugins\datatables\jquery.dataTables.min.js
                     "~/Vendor/plugins/datatables/jquery.dataTables.min.js",
                     "~/Scripts/notify.min.js",
                     "~/Scripts/nanobar.min.js"
                     ));


            //bundles.Add(new ScriptBundle("~/bundles/datatable").Include(                
            //         "~/Scripts/notify.min.js",
            //         "~/Scripts/nanobar.min.js"
            //         ));
        }
    }
}
