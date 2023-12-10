using GestionHopital.data;
using GestionHopital.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace GestionHopital.Controllers
{
    public class SecretaryController : Controller
    {
        // GET: SecretaryController1
        private readonly HopitalDbContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment; // Add this
        public SecretaryController(HopitalDbContext db, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment; // Initialize the hosting environment
        }
        public ActionResult Index()
        {
            var data = _db.OtherStaffs.Include(p => p.user).Include(p=>p.Doctor).ToList();
            return View(data);
            
        }

        // GET: SecretaryController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        // Liste des sec
        public ActionResult GetSecretary()
        {
            try
            {

               
                var data = _db.OtherStaffs
                     .Where(u => u.user.RoleId == 3)
                   .Include(u => u.user.role)
                    .Include(o => o.user)
                    .Include(p => p.Doctor)
                    .ToList();

                return View(data);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return View(new List<OtherStaff>());
            }
        }





        // GET: SecretaryController1/Create
        public ActionResult CreateSecretary()
        {
          
            var doctors = _db.Doctors.ToList();

            var staff = new OtherStaff();
            ViewData["doctor"] = doctors;
          
            return View(staff);
            
        }

        // POST: SecretaryController1/Create
        [HttpPost]
       
        public ActionResult CreateSecretary(OtherStaff collection)
        {
            if (collection == null)
            { return RedirectToAction("index"); }
            _db.OtherStaffs.Add(collection);
            collection.user.RoleId = _db.roles.FirstOrDefault(p => p.RoleName == "Staff").Id;
            _db.users.Add(collection.user);
            _db.SaveChanges();
            return RedirectToAction("GetSecretary");
        }

        // GET: SecretaryController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SecretaryController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SecretaryController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SecretaryController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
