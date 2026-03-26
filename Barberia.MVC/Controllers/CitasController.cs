using API_Consumer;
using Barberia.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.MVC.Controllers
{
    public class CitasController : Controller
    {
        // --- MÉTODOS AUXILIARES PARA LLENAR DROPDOWNS ---
        private void CargarListasEnViewBag()
        {
            ViewBag.ClientesList = Crud<Cliente>.GetAll().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.Nombre_Cli} {c.Apellido_Cli}"
            }).ToList();

            ViewBag.BarberosList = Crud<Barbero>.GetAll().Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = $"{b.Nombre_Bar} {b.Apellido_Bar}"
            }).ToList();

            ViewBag.ServiciosList = Crud<Servicio>.GetAll().Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = $"{s.Nombre_Serv} (${s.Precio_Serv})"
            }).ToList();

            ViewBag.HorariosList = Crud<Horario>.GetAll().Select(h => new SelectListItem
            {
                Value = h.Id.ToString(),
                Text = $"{h.Fecha:dd/MM/yyyy} - {h.HoraInicio}"
            }).ToList();
        }

        // --- ACCIONES DEL CONTROLADOR ---

        // GET: Citas
        public ActionResult Index()
        {
            var citas = Crud<Cita>.GetAll();

            // Enviamos los objetos completos para que la vista pueda buscar nombres por ID
            ViewBag.Clientes = Crud<Cliente>.GetAll();
            ViewBag.Barberos = Crud<Barbero>.GetAll();
            ViewBag.Servicios = Crud<Servicio>.GetAll();
            ViewBag.Horarios = Crud<Horario>.GetAll();

            return View(citas);
        }

        // GET: Citas/Details/5
        public ActionResult Details(int Id)
        {
            var cita = Crud<Cita>.GetById(Id);
            if (cita == null) return NotFound();

            // Enviamos los datos para mostrar nombres en lugar de IDs en los detalles
            ViewBag.Cliente = Crud<Cliente>.GetById(cita.ClienteId);
            ViewBag.Barbero = Crud<Barbero>.GetById(cita.BarberoId);
            ViewBag.Servicio = Crud<Servicio>.GetById(cita.ServicioId);
            ViewBag.Horario = Crud<Horario>.GetById(cita.HorarioId);

            return View(cita);
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            CargarListasEnViewBag();
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
                CargarListasEnViewBag();
                return View(cita);
            }
        }

        // GET: Citas/Edit/5
        public ActionResult Edit(int Id)
        {
            var cita = Crud<Cita>.GetById(Id);
            if (cita == null) return NotFound();

            CargarListasEnViewBag();
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
                CargarListasEnViewBag();
                return View(cita);
            }
        }

        // GET: Citas/Delete/5
        public ActionResult Delete(int Id)
        {
            var cita = Crud<Cita>.GetById(Id);
            if (cita == null) return NotFound();

            // Para que en la confirmación de borrado se vea a quién estamos borrando
            ViewBag.Cliente = Crud<Cliente>.GetById(cita.ClienteId);
            ViewBag.Barbero = Crud<Barbero>.GetById(cita.BarberoId);

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