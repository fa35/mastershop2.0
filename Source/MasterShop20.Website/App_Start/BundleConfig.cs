using System.Web.Optimization;

namespace MasterShop20.Website
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bootstrap/style/stuff")
                .Include("~/Content/bootstrap/css/bootstrap-theme.min.css")
                .Include("~/Content/bootstrap/css/bootstrap.min.css"));
        }
    }
}