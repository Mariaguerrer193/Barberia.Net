using API_Consumer; 
using Barberia.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Barberia.MVC.Controllers
{
    public class HorariosController : Controller
    {
        // GET: Horarios
        public ActionResult Index()
        {
            var horarios = Crud<Horario>.GetAll();
            return View(horarios);
        }

        // GET: Horarios/Details/5
        public ActionResult Details(int Id)
        {
            var horario = Crud<Horario>.GetById(Id);
            if (horario == null) return NotFound();

            return View(horario);
        }

        // GET: Horarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Horarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Horario horario)
        {
            try
            {
                Crud<Horario>.Create(horario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(horario);
            }
        }

        // GET: Horarios/Edit/5
        public ActionResult Edit(int Id)
        {
            var horario = Crud<Horario>.GetById(Id);
            if (horario == null) return NotFound();

            return View(horario);
        }

        // POST: Horarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, Horario horario)
        {
            try
            {
                Crud<Horario>.Update(Id, horario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(horario);
            }
        }

        // GET: Horarios/Delete/5
        public ActionResult Delete(int Id)
        {
            var horario = Crud<Horario>.GetById(Id);
            if (horario == null) return NotFound();

            return View(horario);
        }

        // POST: Horarios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id, Horario horario)
        {
            try
            {
                Crud<Horario>.Delete(Id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(horario);
            }
        }
    }
}