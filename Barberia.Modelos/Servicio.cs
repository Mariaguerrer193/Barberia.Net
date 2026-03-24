using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberia.Modelos
{
    public class Servicio
    {
        [Key] public int Id { get; set; }
        public string Nombre_Serv {  get; set; }
        public string Duracion_Serv { get; set; }
        public string Precio_Serv { get; set; }

        List<Cita>? Citas { get; set; } = new List<Cita>();
    }
}
