using API_Consumer;
using Barberia.Modelos;
using Barberia.Servicios.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Barberia.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        // GET: Account
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            email = email.Trim().ToLower();

            if (await _authService.Login(email, password))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Email o contraseña incorrectos.";
                return View("Index");
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string Nombre_Cli,  string Apellido_Cli,  string Telefono_Cli, string Correo_cli, string contraseña_Cli)
        {
            Correo_cli = Correo_cli.Trim().ToLower();

            var usuario = Crud<Cliente>.GetAll()
                .FirstOrDefault(u => u.Correo_Cli.ToLower() == Correo_cli);

            if (usuario != null)
            {
                ViewBag.ErrorMessage = "Esta cuenta ya está asociada a este correo";
                return View();
            }

            if (await _authService.Register(0,Nombre_Cli, Apellido_Cli, Telefono_Cli, Correo_cli, contraseña_Cli))
            {
                return RedirectToAction("Index", "Account");
            }

            ViewBag.ErrorMessage = "Error al crear el usuario";
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            // Elimina la cookie de autenticación
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Index", "Account");
        }


    }
}