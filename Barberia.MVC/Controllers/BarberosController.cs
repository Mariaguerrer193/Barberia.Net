using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Barberia.MVC.Controllers
{
    public class BarberosController : Controller
    {
        // GET: BarberosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BarberosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BarberosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BarberosController/Create
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

        // GET: BarberosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BarberosController/Edit/5
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

        // GET: BarberosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BarberosController/Delete/5
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
