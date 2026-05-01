using Microsoft.EntityFrameworkCore;
using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.MiDbContext
{


        public class MyAppDbContext : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseInMemoryDatabase("MyDbTest");
            }
        public DbSet<Cliente> Clientes { get; set; } 
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<ListaDeEspera> ListasDeEspera { get; set; }
        public DbSet<EstadoMesa> EstadosMesa { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<TurnoReserva> TurnoReservas { get; set; }
        public DbSet<EstadoReserva> EstadosReserva { get; set; }
        public DbSet<Zona> Zonas { get; set; }


}
    
}
