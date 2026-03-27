using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Barberia.Controllers
{
    public class AdminController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        [HttpPost]
        public IActionResult Validar(string codigoAdmin)
        {
            const string secreto = "0993587216-JGC";
            if (codigoAdmin == secreto)
            {
                //modificacion para poder hacer que el lyout sepa que poner el la barra de encimita 
                HttpContext.Session.SetString("UserRole", "Admin");
                return RedirectToAction("Index", "Citas");
            }
            else
            {
                
                ViewBag.Error = "CÓDIGO DE SEGURIDAD INCORRECTO";
                return View("Index");
            }
        }
    }
}