using Microsoft.AspNetCore.Mvc;

namespace clinique.Controllers
{
    [Route("admin/dashboard")]
  
    public class DashbordController : Controller
    {
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
