using System.Diagnostics;
using GrPhotosCore.Domain;
using GrPhotosCore.Infrastructure;
using GrPhotosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Newtonsoft.Json;

namespace GrPhotosCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly INopFileProvider _fileProvider;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            INopFileProvider fileProvider,
            ILogger<HomeController> logger
        ) {
            _fileProvider = fileProvider;
            _logger = logger;
        }

        public IActionResult Index() {
            
            var carousel = SotosExifs();

            ViewBag.css = "home";
            return View(carousel);
        }

        private List<Exif>? SotosExifs() {
            // get exifs file
            var filePathJson = _fileProvider.MapPath("~/App_Data/exif.json");

            // read all data
            var jsonData = System.IO.File.ReadAllText(filePathJson);

            // declare date time format from exif
            var jsonSettings = new JsonSerializerSettings {
                DateFormatString = "yyyy:MM:dd HH:mm:ss" //this won't help much for the 'date' only field!
            };

            // list of exifs
            var carousel = JsonConvert.DeserializeObject<List<Exif>>(jsonData, jsonSettings);
            return carousel;
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

            var photos = SotosExifs();

            ViewBag.css = "page page-portfolio";
            ViewBag.Message = "Your application description page.";

            return View(photos);
        }

        public IActionResult PortfolioDetails(int id) {

            var photos = SotosExifs();
            var img = photos.FirstOrDefault(m => m.Id == id);

            ViewBag.css = "single single-portfolio";
            ViewBag.Message = "Your application description page.";

            return View(img);
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