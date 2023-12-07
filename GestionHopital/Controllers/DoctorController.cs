using GestionHopital.data;
using GestionHopital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System.Runtime.Intrinsics.Arm;
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
using Microsoft.AspNetCore.Mvc.Rendering;
namespace GestionHopital.Controllers
{
    public class DoctorController : Controller
    {
        private readonly HopitalDbContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment; // Add this
        public DoctorController(HopitalDbContext db, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment; // Initialize the hosting environment
        }
        [HttpGet]
        public ActionResult CreateDoctor()
        {
            // Fetch the list of departments from the database
            var departments = _db.Departments.ToList();

            // Create a new instance of the Doctor model
            var doctor = new Doctor();
            ViewData["departement"]=departments;
            // Set the Departments property in the Doctor model
            // Set the Departments property in the ViewBag
            ViewBag.Departments = new SelectList(departments, "DeptNo", "DepartmentName");


            // Return the view with the populated Doctor model
            return View(doctor);
        }
        public ActionResult CreateDoctor(Doctor doc,string departement, IFormFile img)

        {
            if (doc == null)
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
                    return View(doc);
                }

                // Generate a unique filename
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(img.FileName);

                // Save the image to the desired folder
                var destinationPath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "doctors", fileName);
              
                using (var fileStream = new FileStream(destinationPath, FileMode.Create))
                {
                    img.CopyTo(fileStream);
                }

                // Set the 'img' property of the 'Doctors' object
                doc.img = fileName;
            }
            else
            {
                // If no image is uploaded, set a default value for the 'img' property
                doc.img = "default_image.jpg"; // Replace with an appropriate default value
            }
            int dep = _db.Departments.FirstOrDefault(d => d.DeptName == departement).DeptNo;
            doc.DeptNo = dep;
            // Add the 'Doctors' object to the database
            //doc.Status = "Doctor";
            // Set the 'Address' property of the 'Doctors' object
          
            doc.Address = doc.Address ?? "Default Address";  // Replace with the actual logic or default value
                                                             // Set the 'Phone' property of the 'Doctors' object
            doc.Phone = doc.Phone ?? "Default Phone";  // Replace with the actual logic or default value
                                                       // Set the 'Qualification' property of the 'Doctors' object
            doc.Qualification = "Some default qualification";
            // Set the 'Gender' property of the 'Doctors' object
            doc.Gender = "Some default gender";
            // Set the 'Specialization' property of the 'Doctors' object
            doc.Specialization = "Some default specialization";  // Replace with the actual specialization from your form

            _db.Doctors.Add(doc);


            return RedirectToAction("GetDoctor");

        }

        [HttpGet]
        // Liste des GetDepartment
        public ActionResult GetDoctor()
        {
            var data = _db.Doctors.ToList();
            return View(data);
        }
    }
}
