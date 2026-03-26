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
        public IActionResult Validar(string codigoAdmin)
        {
            
            const string secreto = "0993587216-JGC";

            if (codigoAdmin == secreto)
            {
                
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