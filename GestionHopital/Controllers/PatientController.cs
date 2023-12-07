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
        public ActionResult EditPatient(int id)
        {

            var patientObj = _db.Patients.Where(x => x.PatientID == id).FirstOrDefault();



            return View(patientObj);
        }

        [HttpPost]
        public ActionResult EditPatient(int id, Patient pat)
        {
            var patientObj = _db.Patients.Where(x => x.PatientID == id).FirstOrDefault();



            // Mettez à jour les propriétés du patient
            patientObj.Name = pat.Name;
            patientObj.Phone = pat.Phone;
            patientObj.Address = pat.Address;
            patientObj.BirthDate = pat.BirthDate;
            patientObj.Gender = pat.Gender;


            _db.SaveChanges();

            // Vous pouvez rediriger vers une vue de confirmation ou une autre action si nécessaire
            return RedirectToAction("GetPatient"); // Ou une autre action ou vue appropriée
        }









        public ActionResult DeletePatient(int id)
        {
            var Patobj = _db.Patients.Where(x => x.PatientID == id).FirstOrDefault();
            _db.Patients.Remove(Patobj);
            _db.SaveChanges();
            return RedirectToAction("GetPatient");
        }


        public ActionResult DetailsPatient(int id)
        {
            var Patobj = _db.Patients.Where(x => x.PatientID == id).FirstOrDefault();



            return View(Patobj);
        }
    }
}
