using System.Web;
using System.Web.Optimization;

namespace WebProject
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/admin-lte/js").Include(
             "~/admin-lte/js/app.js",
             "~/admin-lte/plugins/fastclick/fastclick.js",
             "~/admin-lte/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js",
             "~/admin-lte/plugins/select2/select2.full.min.js",
             "~/admin-lte/plugins/iCheck/icheck.min.js",
             "~/admin-lte/plugins/datatables/jquery.dataTables.min.js",
             "~/admin-lte/plugins/datatables/dataTables.bootstrap.min.js",
             "~/admin-lte/plugins/slimScroll/jquery.slimscroll.min.js",
             "~/admin-lte/plugins/datepicker/bootstrap-datepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                       "~/admin-lte/css/AdminLTE.min.css",
                      "~/admin-lte/css/skins/skin-green.css",
                        "~/admin-lte/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css",
                        "~/admin-lte/plugins/select2/select2.min.css",
                        "~/admin-lte/plugins/iCheck/all.css",
                        "~/admin-lte/plugins/datatables/dataTables.bootstrap.css",
                        "~/admin-lte/plugins/datepicker/datepicker3.css"));
        }
    }
}
