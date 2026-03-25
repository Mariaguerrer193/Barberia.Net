using API_Consumer;
using Barberia.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Barberia.MVC.Controllers
{
    public class ServiciosController : Controller
    {
        // GET: Servicios
        public ActionResult Index()
        {
            // Pide al API todos los servicios (Corte, Barba, etc.)
            var servicios = Crud<Servicio>.GetAll();
            return View(servicios);
        }

        // GET: Servicios/Details/5
        public ActionResult Details(int Id)
        {
            var servicio = Crud<Servicio>.GetById(Id);
            if (servicio == null) return NotFound();

            return View(servicio);
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servicios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Servicio servicio)
        {
            try
            {
                Crud<Servicio>.Create(servicio);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(servicio);
            }
        }

        // GET: Servicios/Edit/5
        public ActionResult Edit(int Id)
        {
            var servicio = Crud<Servicio>.GetById(Id);
            if (servicio == null) return NotFound();

            return View(servicio);
        }

        // POST: Servicios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, Servicio servicio)
        {
            try
            {
                Crud<Servicio>.Update(Id, servicio);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(servicio);
            }
        }

        // GET: Servicios/Delete/5
        public ActionResult Delete(int Id)
        {
            var servicio = Crud<Servicio>.GetById(Id);
            if (servicio == null) return NotFound();

            return View(servicio);
        }

        // POST: Servicios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id, Servicio servicio)
        {
            try
            {
                Crud<Servicio>.Delete(Id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(servicio);
            }
        }
    }
}