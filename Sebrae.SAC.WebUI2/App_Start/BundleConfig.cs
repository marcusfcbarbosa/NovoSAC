using System.Web;
using System.Web.Optimization;

namespace SAC_.WebUI2
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/libs").Include(
                "~/Scripts/libs/jquery/jquery-1.11.2.min.js",
                "~/Scripts/libs/bootstrap/bootstrap.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/core").Include(
                 "~/Scripts/core/source/App.js",
                 "~/Scripts/core/source/AppNavigation.js",
                 "~/Scripts/core/source/AppForm.js"));

            bundles.Add(new ScriptBundle("~/bundles/form").Include(
                "~/Scripts/libs/form/select2.min.js",
                "~/Scripts/libs/form/jquery.multi-select.js",
                "~/Scripts/libs/form/jquery.inputmask.bundle.min.js",
                "~/Scripts/libs/form/bootstrap-datepicker.js", 
                "~/Scripts/libs/datatable/jquery.dataTables.min.js",
                "~/Scripts/libs/datatable/dataTables.tableTools.min.js",
                "~/Scripts/core/demo/DemoTableDynamic.js",
                "~/Scripts/core/demo/DemoFormComponents.js"));

            bundles.Add(new ScriptBundle("~/bundles/css").Include(
                 "~/Content/theme/bootstrap.css",
                 "~/Content/theme/materialadmin.css"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/theme/font-awesome.min.css",
                 "~/Content/theme/material-design-iconic-font.min.css",
                 "~/Content/theme/material-design-iconic-font.css"));

            bundles.Add(new ScriptBundle("~/Content/form").Include(
                "~/Content/theme/libs/select2.css",
                "~/Content/theme/libs/multi-select.css",
                "~/Content/theme/libs/jquery.dataTables.css",
                "~/Content/theme/libs/dataTables.tableTools.css",
                "~/Content/theme/libs/datepicker3.css"));
        }
    }
}
