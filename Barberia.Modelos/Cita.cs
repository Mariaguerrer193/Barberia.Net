using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberia.Modelos
{
    public class Cita
    {
        [Key] public int Id { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        [ForeignKey("BarberoId")]
        public int BarberoId { get; set; }
        public Barbero? Barbero { get; set; }

        [ForeignKey("ServicioId")]
        public int ServicioId { get; set; }
        public Servicio? Servicio { get; set; }

        [ForeignKey("HorarioId")]
        public int HorarioId { get; set; }
        public Horario? Horario { get; set; }
    }
}

