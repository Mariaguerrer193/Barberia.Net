using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberia.Modelos
{
    public class Horario
    {
        [Key] public int Id { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }

        List<Cita>? Citas { get; set; } = new List<Cita>();
    }
}
