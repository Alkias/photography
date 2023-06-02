using System.Diagnostics;
using GrPhotosCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GrPhotosCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            ViewBag.css = "home";
            return View();
        }

        public IActionResult About() {
            ViewBag.css = "page page-about";
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Team() {
            ViewBag.css = "page page-about";
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Blog() {
            ViewBag.css = "blog";
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult BlogPost() {
            ViewBag.css = "single single-post";
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Portfolio() {
            ViewBag.css = "page page-portfolio";
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult PortfolioDetails() {
            ViewBag.css = "single single-portfolio";
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}