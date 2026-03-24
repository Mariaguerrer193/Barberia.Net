using API_Consumer;
using Barberia.Modelos;
using Barberia.Servicios.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Blazor;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;


namespace Barberia.Servicios
{
    public class AuthService: Interfaces.IAuthService
    {
         private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Login(string Correo_cli, string password)
        {
            var usuarios = Crud<Cliente>.GetAll();
            foreach (var usuario in usuarios)
            {
                if (usuario.Correo_Cli == Correo_cli)
                {
                    //BCrypt compara el texto plano con el Hash de la base de datos
                    if (BCrypt.Net.BCrypt.Verify(password, usuario.contraseña_Cli))
                    {
                        var datosUsuario = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuario.Nombre_Cli),
                        new Claim(ClaimTypes.Email, usuario.Correo_Cli),
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    };

                        var credencialDigital = new ClaimsIdentity(datosUsuario, "Cookies");
                        var usuarioAutenticado = new ClaimsPrincipal(credencialDigital);

                        await _httpContextAccessor.HttpContext.SignInAsync("Cookies", usuarioAutenticado);
                        return true;
                    }
                }
            }
            return false;
        }



        public async Task<bool> Register(
            int Id,
            string Nombre_Cli,
            string Apellido_Cli,
            string Telefono_Cli,
            string Correo_Cli,
            string contraseña_Cli
            )
        {
            //Verificamos duplicados con endpoints específicos
            var usuarioExistente = Crud<Cliente>.GetAll()
                 .FirstOrDefault(u => u.Correo_Cli == Correo_Cli);

            if (usuarioExistente != null)
            {
                Console.WriteLine("Error: El correo ya está registrado.");
                return false;
            }

            try
            {
                //CREACIÓN DEL OBJETO USUARIO CON HASH SEGURIDAD
                var nuevoUsuario = new Cliente
                {
                    Id = 0,
                    Nombre_Cli = Nombre_Cli,
                    Apellido_Cli = Apellido_Cli,
                    Telefono_Cli = Telefono_Cli, 
                    Correo_Cli = Correo_Cli,
                    
                    contraseña_Cli = contraseña_Cli
                };

                Crud<Cliente>.Create(nuevoUsuario);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar usuario: {ex.Message}");
                return false;
            }
        }
    }
}







