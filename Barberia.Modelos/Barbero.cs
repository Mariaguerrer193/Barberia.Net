using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberia.Modelos
{
    public class Barbero
    {
        [Key] public int Id { get; set; }
        public string Nombre_Bar {  get; set; }
        public string Apellido_Bar { get; set; }
        public string Telefono {  get; set; }

        List<Cita>? Citas { get; set; } = new List<Cita>();
    }
}
