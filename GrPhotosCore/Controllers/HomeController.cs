using System.Diagnostics;
using GrPhotosCore.Domain;
using GrPhotosCore.Infrastructure;
using GrPhotosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Newtonsoft.Json;
using GrPhotosCore.Services;

namespace GrPhotosCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly INopFileProvider _fileProvider;
        private readonly IExifService _exifService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            INopFileProvider fileProvider,
            IExifService exifService,
            ILogger<HomeController> logger
        ) {
            _fileProvider = fileProvider;
            _exifService = exifService;
            _logger = logger;
        }

        public async Task<IActionResult>  Index() {
            
            var carousel = await _exifService.GetHomeExifs("exif");

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

        public async Task<IActionResult> Portfolio(string gallery= "Ασπρόμαυρη πόλη") {

            var model = await PreparePortfolioModel(gallery);

            ViewBag.css = "page page-portfolio";
            ViewBag.Message = "Your application description page.";

            return View(model);
        }

        /// <summary>
        /// Returns a Portfolio model filtered by Gallery
        /// </summary>
        /// <param name="gallery">Gallery Keyword</param>
        /// <returns></returns>
        private async Task<PortfolioModel> PreparePortfolioModel(string gallery) {
            var model = new PortfolioModel();

            var galleries = await _exifService.GetGalleriesAsync("exif");
            model.Geleries = galleries;
            model.Categories = new List<string>();

            var exifs = SotosExifs()!.Where(x => x.Gallery == gallery).ToList();
            model.Exifs = exifs;
            model.ActiveGallery = gallery;
            return model;
        }

        [HttpPost]
        public async Task<IActionResult> GetGallery(string gallery = "Ασπρόμαυρη πόλη") {

            var model = await PreparePortfolioModel(gallery);

            ViewBag.css = "page page-portfolio";
            ViewBag.Message = "Your application description page.";

            return PartialView("_Gallery",model);
        }


        public IActionResult PortfolioDetails(int id) {

            var exifs = SotosExifs();
            if (exifs != null) {
                var exif = exifs.FirstOrDefault(m => m.Id == id);

                ViewBag.css = "single single-portfolio";
                ViewBag.Message = "Your application description page.";

                return View(exif);
            }

            return View(null);
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