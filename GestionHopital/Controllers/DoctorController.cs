using GestionHopital.data;
using GestionHopital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            ViewData["departement"] = departments;
            // Set the Departments property in the Doctor model
            // Set the Departments property in the ViewBag
            ViewBag.Departments = new SelectList(departments, "DeptNo", "DepartmentName");


            // Return the view with the populated Doctor model
            return View(doctor);
        }
        public ActionResult CreateDoctor(Doctor doc, string departement, IFormFile img)

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

            doc.Address = doc.Address ?? "Default Address";  // Replace with the actual logic or default value
                                                             // Set the 'Phone' property of the 'Doctors' object
            doc.Phone = doc.Phone ?? "Default Phone";  // Replace with the actual logic or default value
                                                       // Set the 'Qualification' property of the 'Doctors' object
            doc.Qualification = doc.Qualification ?? "Some default qualification";

            // Set the 'Specialization' property of the 'Doctors' object
            doc.Specialization = doc.Specialization ?? "Some default specialization";  // Replace with the actual specialization from your form
            doc.BirthDate = DateTime.Parse(Request.Form["birthdate"]);
            _db.Doctors.Add(doc);
            _db.SaveChanges();

            return RedirectToAction("GetDoctor");

        }

        [HttpGet]
        // Liste des GetDepartment
        public ActionResult GetDoctor()
        {
            var data = _db.Doctors.Include(p => p.Department).ToList();
            return View(data);
        }

        //Edit
        [HttpGet]
        public ActionResult EditDoctor(int DoctorID)
        {
            var DoctorObj = _db.Doctors.Find(DoctorID);

            // Fetch the list of departments from the database
            List< Department> departments = _db.Departments.ToList();

            ViewData["departement"] = departments;
            ViewBag.Departments = new SelectList(departments, "DeptNo", "DeptName");

            return View(DoctorObj);
        }

        [HttpPost]
        public ActionResult EditDoctor( Doctor doc,  IFormFile img)
        {
            // Find the doctor with the specified ID
            var DoctorObj = _db.Doctors.Find(doc.DoctorID);

            // Check if the doctor with the specified ID exists
            if (DoctorObj == null)
            {
                // Handle the case where the doctor is not found, e.g., return a not found view
                return NotFound();
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
 

            // Update properties of the existing doctor
            DoctorObj.Name = doc.Name;
            DoctorObj.Phone = doc.Phone;
            DoctorObj.Address = doc.Address;
            DoctorObj.BirthDate = doc.BirthDate;
            DoctorObj.Gender = doc.Gender;
            DoctorObj.DeptNo = doc.DeptNo;
            DoctorObj.Qualification = doc.Qualification;
            DoctorObj.Specialization = doc.Specialization;
            DoctorObj.Work_Experience = doc.Work_Experience;
            DoctorObj.Status = doc.Status;
            DoctorObj.img = doc.img;
            
            _db.SaveChanges();

            // Redirect to an appropriate action after successful update
            return RedirectToAction("GetDoctor");
        }
        public ActionResult DeleteDoctor(int DoctorID)
        {
            var doctorToDelete = _db.Doctors.FirstOrDefault(d => d.DoctorID == DoctorID);

            if (doctorToDelete == null)
            {
                // Handle the case where the doctor with the specified ID is not found,
                // e.g., return a not found view or a redirect to an error page.
                return NotFound();
            }

            _db.Doctors.Remove(doctorToDelete);
            _db.SaveChanges();

            return RedirectToAction("GetDoctor");
        }




        public ActionResult DetailsDoctor(int DoctorID)
        {
            // Fetch the specific doctor based on the id
            var doctor = _db.Doctors.FirstOrDefault(x => x.DoctorID == DoctorID);

            // Check if the doctor is found
            if (doctor == null)
            {
                // Optionally, handle the case where the doctor is not found, e.g., return a not found view
                return NotFound();
            }

            // Pass the doctor object to the view
            return View(doctor);
        }

    }
}

