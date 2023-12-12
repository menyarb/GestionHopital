using GestionHopital.data;
using GestionHopital.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GestionHopital.Controllers
{
    public class HomeController : Controller
    {
        private readonly HopitalDbContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment; // Add this
        private readonly ILogger<HomeController> _logger;
        public HomeController(HopitalDbContext db, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment; // Initialize the hosting environment
        }

        [HttpGet]
        // Liste des GetDepartment
        public ActionResult GetHome()
        {
            var data = _db.Departments.ToList();
            return View(data);
        }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}