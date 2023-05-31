using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrPhotos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() {
            ViewBag.css = "home";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.css = "page page-about";
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Team()
        {
            ViewBag.css = "page page-about";
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Blog()
        {
            ViewBag.css = "blog";
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult BlogPost()
        {
            ViewBag.css = "single single-post";
            ViewBag.Message = "Your application description page.";

            return View();
        }




        public ActionResult Portfolio()
        {
            ViewBag.css = "page page-portfolio";
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult PortfolioDetails()
        {
            ViewBag.css = "single single-portfolio";
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}