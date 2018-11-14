using System.Web;
using System.Web.Optimization;

namespace VidlyTakeTwo
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {//lib is short for library
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootbox.js",//these are libraries we added, making client-side dev easier
                        "~/Scripts/respond.js",
                        "~/scripts/datatables/jquery.datatables.js",
                        "~/scripts/datatables/datatables.bootstrap.js",
                        "~/scripts/typeahead.bundle.js"
                        ));

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

           
//************ Below is where I changed the style to bootstrap-lumen********************
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-lumen.css",
                      "~/content/datatables/css/datatables.bootstrap.css",
                      "~/Content/typeahead.css",
                      "~/Content/site.css"));
        }
    }
}
