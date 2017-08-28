using System.Web;
using System.Web.Optimization;

namespace VidlyTakeTwo
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(//by default this bundle is not
                        "~/Scripts/jquery.validate*"));//not referenced anywhere. When we reference it,
//the validating of data annontation attributes such as Required and StringLength(255) is done on the 
//client machine, not the web server. This is done using JQuery. It makes the app faster. This only works
//with standard, default attributes, not custom-made ones. For custom ones, you would have to write the
//JQuery as well.

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
//************ Below is where I changed the style to bootstrap-lumen********************
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-lumen.css",
                      "~/Content/site.css"));
        }
    }
}
