using API_Consumer;
using Barberia.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Barberia.MVC.Controllers
{
    public class CitasController : Controller
    {
        // Métodos auxiliares para llenar los DropDownLists
        private List<SelectListItem> GetClientes()
        {
            return Crud<Cliente>.GetAll().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.Nombre_Cli} {c.Apellido_Cli}"
            }).ToList();
        }

        private List<SelectListItem> GetBarberos()
        {
            return Crud<Barbero>.GetAll().Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = $"{b.Nombre_Bar} {b.Apellido_Bar}"
            }).ToList();
        }

        private List<SelectListItem> GetServicios()
        {
            return Crud<Servicio>.GetAll().Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = $"{s.Nombre_Serv} (${s.Precio_Serv})"
            }).ToList();
        }

        private List<SelectListItem> GetHorarios()
        {
            return Crud<Horario>.GetAll().Select(h => new SelectListItem
            {
                Value = h.Id.ToString(),
                Text = $"{h.Fecha:dd/MM/yyyy} - {h.HoraInicio}"
            }).ToList();
        }

        // GET: Citas
        public ActionResult Index()
        {
            var citas = Crud<Cita>.GetAll();
            return View(citas);
        }

        // GET: Citas/Details/5
        public ActionResult Details(int Id)
        {
            var cita = Crud<Cita>.GetById(Id);
            if (cita == null) return NotFound();
            return View(cita);
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            ViewBag.Clientes = GetClientes();
            ViewBag.Barberos = GetBarberos();
            ViewBag.Servicios = GetServicios();
            ViewBag.Horarios = GetHorarios();
            return View();
        }

        // POST: Citas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cita cita)
        {
            try
            {
                Crud<Cita>.Create(cita);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                
                ViewBag.Clientes = GetClientes();
                ViewBag.Barberos = GetBarberos();
                ViewBag.Servicios = GetServicios();
                ViewBag.Horarios = GetHorarios();
                return View(cita);
            }
        }

        // GET: Citas/Edit/5
        public ActionResult Edit(int Id)
        {
            var cita = Crud<Cita>.GetById(Id);
            if (cita == null) return NotFound();

            ViewBag.Clientes = GetClientes();
            ViewBag.Barberos = GetBarberos();
            ViewBag.Servicios = GetServicios();
            ViewBag.Horarios = GetHorarios();
            return View(cita);
        }

        // POST: Citas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, Cita cita)
        {
            try
            {
                Crud<Cita>.Update(Id, cita);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(cita);
            }
        }

        // GET: Citas/Delete/5
        public ActionResult Delete(int Id)
        {
            var cita = Crud<Cita>.GetById(Id);
            if (cita == null) return NotFound();
            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id, Cita cita)
        {
            try
            {
                Crud<Cita>.Delete(Id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(cita);
            }
        }
    }
}