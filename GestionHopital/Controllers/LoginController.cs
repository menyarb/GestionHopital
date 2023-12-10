using GestionHopital.data;
using GestionHopital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clinique.Controllers
{
    
     
    public class LoginController : Controller
    {
        private readonly HopitalDbContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment; // Add this
        public LoginController(HopitalDbContext db, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment; // Initialize the hosting environment
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Login(User user)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                var logindUser = _db.users.Where(p => p.Password == user.Password && p.Email == user.Email).FirstOrDefault();
                if (logindUser == null)
                {
                    return NotFound();
                }

                HttpContext.Session.SetString("UserName", logindUser.Name.ToString());
                HttpContext.Session.SetString("UserId", logindUser.Id.ToString());
               
            }
            return RedirectToAction("Doctor/CreateDoctor");
        }
    }
}
