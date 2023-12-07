using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionHopital.Controllers
{
    public class OtherStaffController : Controller
    {
        // GET: OtherStaffController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OtherStaffController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OtherStaffController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OtherStaffController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: OtherStaffController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OtherStaffController/Edit/5
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

        // GET: OtherStaffController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OtherStaffController/Delete/5
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
