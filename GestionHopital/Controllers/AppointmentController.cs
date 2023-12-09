using GestionHopital.data;
using GestionHopital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GestionHopital.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly HopitalDbContext _db;

        public AppointmentController(HopitalDbContext db)
        {
            _db = db;
        }

        public ActionResult GetAppointment()
        {
            var data = _db.Appointments.ToList();
            return View(data);
        }
        public ActionResult CreateAppointment()
        {
            // You may need to provide necessary data to populate dropdowns, etc.
            ViewBag.Doctors = _db.Doctors.ToList();
            ViewBag.Patients = _db.users.ToList();
            return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAppointment(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                // Assuming you have appropriate Doctor and Patient entities in the database
                Doctor doctor = _db.Doctors.Find(appointment.DoctorID);
                User patient = _db.users.Find(appointment.PatientID);

                if (doctor != null && patient != null)
                {
                    // Assign navigation properties
                    appointment.Doctor = doctor;
                    appointment.Patient = patient;

                    _db.Appointments.Add(appointment);
                    _db.SaveChanges();

                    return RedirectToAction("Index", "Home"); // Redirect to home or another appropriate page
                }
            }

            // If the model state is not valid, return to the form with validation errors
            ViewBag.Doctors = _db.Doctors.ToList();
            ViewBag.Patients = _db.users.ToList();
            return View(appointment);
        }
    }
}
