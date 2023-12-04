using GestionHopital.data;
using GestionHopital.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionHopital.Controllers
{
    public class PatientController : Controller
    {
        private readonly HopitalDbContext _db;

        public PatientController(HopitalDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        // Liste des Patients
        public ActionResult GetPatient()
        {
            var data = _db.Patients.ToList();
            return View(data); 
        }

        [HttpGet]
        public ActionResult CreatePatient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePatient(Patient pat)
        {
            if (pat == null) 
            { return RedirectToAction("GetPatient"); }
            _db.Patients.Add(pat);
            _db.SaveChanges();

            return RedirectToAction("GetPatient");
        }

        [HttpGet]
        public ActionResult EditPatient(int id) {
            //int id = HttpContext.Request.Query["PatientId"];
            var Patobj = _db.Patients.Where(x => x.PatientID == id).FirstOrDefault();
            return View(Patobj);
        }



        public ActionResult DeletePatient(int id)
        {
            //int id = HttpContext.Request.Query["PatientId"];
            var Patobj = _db.Patients.Where(x => x.PatientID == id).FirstOrDefault();
            _db.Patients.Remove(Patobj);
            _db.SaveChanges();  
            return RedirectToAction("GetPatients");
        }


    }
}
