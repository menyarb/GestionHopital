using Microsoft.AspNetCore.Mvc;

namespace clinique.Controllers
{
    
    [Route("admin/login")]
    [Route("admin")]
    public class LoginController : Controller
    {
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
