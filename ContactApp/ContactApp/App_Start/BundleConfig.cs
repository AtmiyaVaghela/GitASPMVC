using System.Web.Optimization;

namespace ContactApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/plugins/datatables/jquery.dataTables.js",
                      "~/plugins/datatables/dataTables.bootstrap.js",
                      "~/plugins/select2/select2.full.min.js",
                      "~/plugins/Bootcards/js/bootcards.min.js",
                      "~/Scripts/Script.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css",
                      "~/plugins/datatables/dataTables.bootstrap.css",
                      "~/plugins/select2/select2.min.css",
                      "~/plugins/Bootcards/css/bootcards-ios.min.css",
                      "~/plugins/Bootcards/css/bootcards-android.min.css",
                      "~/plugins/Bootcards/css/bootcards-desktop.min.css"
                      ));

            BundleTable.EnableOptimizations = true;
        }
    }
}