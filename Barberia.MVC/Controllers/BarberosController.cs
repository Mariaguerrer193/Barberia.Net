using API_Consumer;
using Barberia.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Barberia.MVC.Controllers
{
    public class BarberosController : Controller
    {
        // GET: Barberos
        public ActionResult Index()
        {
            
            var barberos = Crud<Barbero>.GetAll();
            return View(barberos);
        }

        // GET: Barberos/Details/5
        public ActionResult Details(int Id)
        {
            var barbero = Crud<Barbero>.GetById(Id);
            if (barbero == null) return NotFound();

            return View(barbero);
        }

        // GET: Barberos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Barberos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Barbero barbero)
        {
            try
            {
                Crud<Barbero>.Create(barbero);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(barbero);
            }
        }

        // GET: Barberos/Edit/5
        public ActionResult Edit(int Id)
        {
            var barbero = Crud<Barbero>.GetById(Id);
            if (barbero == null) return NotFound();

            return View(barbero);
        }

        // POST: Barberos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, Barbero barbero)
        {
            try
            {
                Crud<Barbero>.Update(Id, barbero);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(barbero);
            }
        }

        // GET: Barberos/Delete/5
        public ActionResult Delete(int Id)
        {
            var barbero = Crud<Barbero>.GetById(Id);
            if (barbero == null) return NotFound();

            return View(barbero);
        }

        // POST: Barberos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id, Barbero barbero)
        {
            try
            {
                Crud<Barbero>.Delete(Id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(barbero);
            }
        }
    }
}