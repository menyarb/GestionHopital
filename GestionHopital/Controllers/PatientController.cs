using GestionHopital.data;
using GestionHopital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;

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
            var data = _db.users.Include(p=>p.role).ToList();
            return View(data);
        }


        [HttpGet]
        public ActionResult CreatePatient()
        {
            return View();
        }
        [HttpGet]
        public ActionResult RegisterPatient()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreatePatient(User pat)
        {
            if (pat == null)
            { return RedirectToAction("GetPatient"); }
            pat.RoleId = _db.roles.FirstOrDefault(d => d.RoleName == "Patient").Id;
            _db.users.Add(pat);
            _db.SaveChanges();

            return RedirectToAction("GetPatient");
        }

        [HttpPost]
        public ActionResult RegisterPatient(User pat)
        {
            if (pat == null)
            { return RedirectToAction("GetPatient"); }
            pat.RoleId = _db.roles.FirstOrDefault(d => d.RoleName == "Patient").Id;
            _db.users.Add(pat);
            _db.SaveChanges();

            return RedirectToAction("index", "Login"); // Replace "Account" with your actual controller name.

        }




        [HttpGet]
        public ActionResult EditPatient(int id)
        {

            var patientObj = _db.users.Where(x => x.Id == id).FirstOrDefault();



            return View(patientObj);
        }

        [HttpPost]
        public ActionResult EditPatient(int id, User pat)
        {
            var patientObj = _db.users.Where(x => x.Id == id).FirstOrDefault();



            // Mettez à jour les propriétés du patient
            patientObj.Name = pat.Name;
            patientObj.Phone = pat.Phone;
            patientObj.Address = pat.Address;
            patientObj.BirthDate = pat.BirthDate;
            patientObj.Gender = pat.Gender;
            patientObj.Password = pat.Password;


            _db.SaveChanges();

            return RedirectToAction("GetPatient"); 
        }









        public ActionResult DeletePatient(int id)
        {
            var Patobj = _db.users.Where(x => x.Id == id).FirstOrDefault();
            _db.users.Remove(Patobj);
            _db.SaveChanges();
            return RedirectToAction("GetPatient");
        }


        public ActionResult DetailsPatient(int id)
        {
            var Patobj = _db.users.Include(p=>p.role).Where(x => x.Id == id).FirstOrDefault();



            return View(Patobj);
        }
    }
}
