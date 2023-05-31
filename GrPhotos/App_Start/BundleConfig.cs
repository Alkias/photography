using System.Web;
using System.Web.Optimization;

namespace GrPhotos
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
        /*
        <script type="text/javascript" src="js/jquery.js"></script>
        <script type='text/javascript' src='js/imagesloaded.pkgd.js'></script>                
        <script type='text/javascript' src='js/isotope.pkgd.js'></script>                
        <script type='text/javascript' src='js/jquery.smartmenus.min.js'></script>           
        <script type='text/javascript' src='js/flickity.pkgd.min.js'></script>
        <script type='text/javascript' src='js/jquery.fitvids.js'></script>                          
        <script type='text/javascript' src='js/jquery.easing.1.3.js'></script>                          
        <script type='text/javascript' src='js/main.js'></script>
        *
        */


            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                        "~/Content/js/jquery.js",
                        "~/Content/js/imagesloaded.pkgd.js",
                        "~/Content/js/isotope.pkgd.js",
                        "~/Content/js/jquery.smartmenus.min.js",
                        "~/Content/js/flickity.pkgd.min.js",
                        "~/Content/js/jquery.fitvids.js",
                        "~/Content/js/jquery.easing.1.3.js",
                        "~/Content/js/main.js",
                        "~/Content/js/zoom.js"));



            /*
             *
                     <link rel="stylesheet" type="text/css"  href='./css/clear.css' />
        <link rel="stylesheet" type="text/css"  href='./css/common.css' />
        <link rel="stylesheet" type="text/css"  href='./css/font-awesome.min.css' />
        <link rel="stylesheet" type="text/css"  href='./css/flickity.min.css' />
        <link rel="stylesheet" type="text/css"  href='./css/sm-clean.css' />        
        <link rel="stylesheet" type="text/css"  href='./css/style.css' />
             */


            bundles.Add(new StyleBundle("~/Content/css/styles").Include(
                      "~/Content/css/clear.css",
                      "~/Content/css/common.css",
                      "~/Content/css/font-awesome.min.css",
                      "~/Content/css/flickity.min.css",
                      "~/Content/css/sm-clean.css",
                      "~/Content/css/style.css",
                      "~/Content/css/zoom.css"));
        }
    }
}
