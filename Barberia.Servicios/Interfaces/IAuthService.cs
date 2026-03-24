using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberia.Servicios.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Login(string email, string password);

        Task<bool> Register(
            int Id,
            string Nombre_Cli,
            string Apellido_Cli,
            string Telefono_Cli,
            string Correo_Cli,
            string contraseña_Cli

        );
    }
}
