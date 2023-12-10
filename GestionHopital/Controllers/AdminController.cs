using GestionHopital.data;
using GestionHopital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionHopital.Controllers
{
    public class AdminController : Controller
    {
        private readonly HopitalDbContext _db;

        public AdminController(HopitalDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public ActionResult CreateAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAdmin(User pat)
        {
            if (pat == null)
            { return RedirectToAction("GetAdmin"); }
            pat.RoleId = _db.roles.FirstOrDefault(d => d.RoleName == "Admin").Id;
            _db.users.Add(pat);
            _db.SaveChanges();

            return RedirectToAction("GetAdmin");
        }


        [HttpGet]

        public ActionResult GetAdmin()
        {

            var data = _db.users
                .Where(u => u.RoleId == 2)
                .Include(u => u.role)
                .ToList();

            return View(data);
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {

            var AdminObj = _db.users.Where(x => x.Id == id).FirstOrDefault();



            return View(AdminObj);
        }

        [HttpPost]
        public ActionResult EditAdmin(int id, User adm)
        {
            var AdminObj = _db.users.Where(x => x.Id == id).FirstOrDefault();



            // Mettez à jour les propriétés du patient
            AdminObj.Name = adm.Name;
            AdminObj.Phone = adm.Phone;
            AdminObj.Address = adm.Address;
            AdminObj.BirthDate = adm.BirthDate;
            AdminObj.Gender = adm.Gender;
            AdminObj.Password = adm.Password;


            _db.SaveChanges();

            return RedirectToAction("GetAdmin");
        }


    }
}
