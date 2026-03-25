using API_Consumer;
using Barberia.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Barberia.MVC.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            
            var clientes = Crud<Cliente>.GetAll();
            return View(clientes);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int Id)
        {
            var cliente = Crud<Cliente>.GetById(Id);
            if (cliente == null) return NotFound();

            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                
                Crud<Cliente>.Create(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(cliente);
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int Id)
        {
            var cliente = Crud<Cliente>.GetById(Id);
            if (cliente == null) return NotFound();

            return View(cliente);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, Cliente cliente)
        {
            try
            {
                Crud<Cliente>.Update(Id, cliente);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(cliente);
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int Id)
        {
            var cliente = Crud<Cliente>.GetById(Id);
            if (cliente == null) return NotFound();

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id, Cliente cliente)
        {
            try
            {
                Crud<Cliente>.Delete(Id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(cliente);
            }
        }
    }
}