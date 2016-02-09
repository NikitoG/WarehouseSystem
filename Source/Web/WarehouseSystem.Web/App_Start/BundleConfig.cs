using System.Web;
using System.Web.Optimization;

namespace WarehouseSystem.Web
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
                      "~/Scripts/theme/js/Chart.min.js",
                      "~/Scripts/theme/js/bootstrap-switch.min.js",
                      "~/Scripts/theme/js/jquery.matchHeight-min.js",
                      "~/Scripts/theme/js/jquery.dataTables.min.js",
                      "~/Scripts/theme/js/dataTables.bootstrap.min.js",
                      "~/Scripts/theme/js/select2.full.min.js",
                      "~/Scripts/theme/js/ace/ace.js",
                      "~/Scripts/theme/js/ace/mode-html.js",
                      "~/Scripts/theme/js/ace/theme-github.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Theme/css/font-awesome.min.css",
                      "~/Content/Theme/css/animate.min.css",
                      "~/Content/Theme/css/bootstrap-switch.min.css",
                      "~/Content/Theme/css/checkbox3.min.css",
                      "~/Content/Theme/css/jquery.dataTables.min.css",
                      "~/Content/Theme/css/dataTables.bootstrap.css",
                      "~/Content/Theme/css/select2.min.css",
                      "~/Content/Theme/home/style.css",
                      "~/Content/Theme/home/flat-blue.css",
                      "~/Content/site.css"));
        }
    }
}