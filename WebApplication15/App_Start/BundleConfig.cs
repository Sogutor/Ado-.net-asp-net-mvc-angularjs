using System.Web;
using System.Web.Optimization;

namespace WebApplication15
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            //js
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/angularJs").Include(
                "~/Scripts/angular.min.js",
                "~/Scripts/angular-animate.js",
                "~/Scripts/angular-material.min.js",
                "~/Scripts/angular-material-mocks.js",
                "~/Scripts/angular-mocks.js",
                "~/Scripts/angular-aria.min.js",
                "~/Scripts/angular-material-mocks.js",
                "~/Scripts/angular-messages.min.js",
                "~/Scripts/angular-route.min.js"));


            //css
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/angularStyles").Include(
                "~/Content/angular-material.css",
                "~/Content/angular-material.min.css",
                "~/Content/bootstrap-theme.min.css",
                "~/Content/angular-material.layouts.min.css",
                "~/Content/angular-material.layout-attributes.min.css"));

        }
    }
}
