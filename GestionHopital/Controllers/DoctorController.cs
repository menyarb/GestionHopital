using GestionHopital.data;
using Microsoft.AspNetCore.Mvc;

namespace GestionHopital.Controllers
{
    public class DoctorController : Controller
    {
        public readonly HopitalDbContext _db;
        public DoctorController(HopitalDbContext _db)
        {
            this._db = _db;
        }
        public ActionResult Index(int deptNo)
        {
            var doctorsInDepartment = _db.Doctors.ToList();
            return View(doctorsInDepartment);
        }
    }
}
