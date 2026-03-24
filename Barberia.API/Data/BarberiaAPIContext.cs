using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Barberia.Modelos;

namespace Barberia.API.Data
{
    public class BarberiaAPIContext : DbContext
    {
        public BarberiaAPIContext (DbContextOptions<BarberiaAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Barberia.Modelos.Barbero> Barbero { get; set; } = default!;
        public DbSet<Barberia.Modelos.Cita> Cita { get; set; } = default!;
        public DbSet<Barberia.Modelos.Cliente> Cliente { get; set; } = default!;
        public DbSet<Barberia.Modelos.Horario> Horario { get; set; } = default!;
        public DbSet<Barberia.Modelos.Servicio> Servicio { get; set; } = default!;
    }
}
