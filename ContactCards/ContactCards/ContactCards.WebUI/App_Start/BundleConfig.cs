using System.Web.Optimization;

namespace ContactCards.WebUI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                 "~/Scripts/jquery.validate*"));
        }
    }
}