using System.Web.Optimization;

namespace OpenOrderFramework
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.numeric.js",
                        "~/Scripts/url.min.js",
                        "~/Scripts/legacy.min.js",
                       "~/Scripts/jquery.stickytableheaders.min.js",
                       "~/Scripts/jquery.fancybox.js",
                       "~/Scripts/moment-with-locales.js",
                       "~/Scripts/bootstrap-datetimepicker.min.js",
                       "~/Scripts/jquery.toast.min.js",
                       "~/Scripts/common.js",
                       "~/Scripts/jquery.multi-select.js",
                         "~/Scripts/card.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                       "~/Scripts/bootstrap-datepicker.js",
                       "~/Scripts/bootstrap-switch.js",
                       "~/Scripts/bootstrap-toggle.js",                  
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-switch.css",
                      "~/Content/bootstrap-toggle.css",
                      "~/Content/variables.less",
                      "~/Content/bootswatch.less",
                      "~/Content/jquery.fancybox.css",
                      "~/Content/bootstrap-datetimepicker.min.css",
                      "~/Content/jquery.toast.min.css",
          "~/Content/multi-select.css",    
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/css2").Include(
          "~/Content/bootstrap.css",
          "~/Content/bootstrap-switch.css",
          "~/Content/bootstrap-toggle.css",
          "~/Content/variables.less",
          "~/Content/bootswatch.less",
          "~/Content/jquery.fancybox.css",
          "~/Content/bootstrap-datetimepicker.min.css",
          "~/Content/jquery.toast.min.css",
          "~/Content/multi-select.css",    
          "~/Content/sitefacybox.css"));
        }
    }
}
