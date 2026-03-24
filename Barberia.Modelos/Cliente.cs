using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberia.Modelos
{
    public class Cliente
    {
        [Key] public int Id { get; set; }
        public string Nombre_Cli {  get; set; }
        public string Apellido_Cli { get; set; }
        public string Telefono_Cli { get; set; }
        public string Correo_Cli { get; set; }
        public string contraseña_Cli { get; set; }


        List<Cita>? Citas { get; set; } = new List<Cita>();
    }
}
