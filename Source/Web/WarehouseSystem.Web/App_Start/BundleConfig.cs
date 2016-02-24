namespace WarehouseSystem.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/timeago").Include(
                        "~/Scripts/jquery.timeago.js",
                      "~/Scripts/js/timeago.js"));

            bundles.Add(new ScriptBundle("~/bundles/font").Include(
                        "~/Scripts/theme/cufon-yui.js",
                      "~/Scripts/theme/League_Gothic_400.font.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/theme").Include(
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
                      "~/Scripts/respond.js",
                      "~/Scripts/theme/app.js",
                      "~/Scripts/theme/index.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                      "~/Scripts/KendoUi/kendo.all.min.js",
                      "~/Scripts/KendoUi/kendo.aspnetmvc.min.js"));

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
                      "~/Content/Theme/home/flat-blue.css"));

            bundles.Add(new StyleBundle("~/Content/kendo").Include(
                      "~/Content/KendoUi/kendo.common.min.css",
                      "~/Content/KendoUi/kendo.bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/home").Include(
                      "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/bundles/login").Include(
                      "~/Scripts/theme/app.js"));

            bundles.Add(new StyleBundle("~/content/toastr", "http://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.min.css")
                .Include("~/Content/toastr.css"));

            bundles.Add(new ScriptBundle("~/bundles/toastr", "http://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js")
                            .Include("~/Scripts/toastr.js"));
        }
    }
}
