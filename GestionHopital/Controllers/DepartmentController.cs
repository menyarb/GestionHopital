using GestionHopital.data;
using GestionHopital.data;
using GestionHopital.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting; // Add this for IWebHostEnvironment
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GestionHopital.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly HopitalDbContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment; // Add this

        public DepartmentController(HopitalDbContext db, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment; // Initialize the hosting environment
        }

        // Liste des Patients
        public ActionResult DepartmentPatient()
        {
            var data = _db.Departments.ToList();
            return View(data);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
         public ActionResult CreateDepartment()
        {
            return View();
        }

    
        public ActionResult CreateDepartment(Department dep, IFormFile img)
        {
            if (dep == null)
            {
                return RedirectToAction("GetDepartment");
            }

            // Check if an image was uploaded
            if (img != null && img.Length > 0)
            {
                // Validate the uploaded file
                if (!img.ContentType.StartsWith("image/"))
                {
                    ModelState.AddModelError("img", "Invalid image format.");
                    return View(dep);
                }

                // Generate a unique filename
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(img.FileName);

                // Save the image to the desired folder
                var destinationPath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "departements", fileName);

                using (var fileStream = new FileStream(destinationPath, FileMode.Create))
                {
                    img.CopyTo(fileStream);
                }

                // Set the 'img' property of the 'Department' object
                dep.img = fileName;
            }
            else
            {
                // If no image is uploaded, set a default value for the 'img' property
                dep.img = "default_image.jpg"; // Replace with an appropriate default value
            }

            // Add the 'Department' object to the database
            _db.Departments.Add(dep);
            _db.SaveChanges();

            return RedirectToAction("GetDepartment");
        }


        [HttpGet]
        // Liste des GetDepartment
        public ActionResult GetDepartment()
        {
            var data = _db.Departments.ToList();
            return View(data);
        }
    }
}
