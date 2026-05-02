using Microsoft.EntityFrameworkCore;
using Proyecto_Progra_II.Entities;
using static Proyecto_Progra_II.Entities.EstadoMesa;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public DbSet<Zona> Zonas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Turno>().HasData(
            new Turno { Id = 1, HoraInicio = DateTime.Parse("08:00"), HoraFin = DateTime.Parse("20:00") }

            );
            modelBuilder.Entity<Mesa>().HasData(
            new Mesa { Id = 1, Capacidad = 4, ZonaId = 1, EstadoMesaId = 1 },
            new Mesa { Id = 2, Capacidad = 4, ZonaId = 1, EstadoMesaId = 2 },
            new Mesa { Id = 3, Capacidad = 4, ZonaId = 1, EstadoMesaId = 3 },
            new Mesa { Id = 4, Capacidad = 4, ZonaId = 1 },
            new Mesa { Id = 5, Capacidad = 4, ZonaId = 2 },
            new Mesa { Id = 6, Capacidad = 4, ZonaId = 2 },
            new Mesa { Id = 7, Capacidad = 4, ZonaId = 2 },
            new Mesa { Id = 8, Capacidad = 4, ZonaId = 2 },
            new Mesa { Id = 9, Capacidad = 4, ZonaId = 3 },
            new Mesa { Id = 10, Capacidad = 4, ZonaId = 3 },
            new Mesa { Id = 11, Capacidad = 4, ZonaId = 3 },
            new Mesa { Id = 12, Capacidad = 4, ZonaId = 3 }

            );
            modelBuilder.Entity<Zona>().HasData(
                new Zona { Id = 1, Nombre = "Terraza" },
                new Zona { Id = 2, Nombre = "Sala Normal" },
                new Zona { Id = 3, Nombre = "Sala VIP" }
                );
            modelBuilder.Entity<EstadoMesa>().HasData(
                new EstadoMesa { Id = 0, TipoBloqueo = TipoBloqueo.Disponible },
               new EstadoMesa { Id = 1, TipoBloqueo = TipoBloqueo.Mantenimiento },
               new EstadoMesa { Id = 2, TipoBloqueo = TipoBloqueo.EventoEspecial },
               new EstadoMesa { Id = 3, TipoBloqueo = TipoBloqueo.Reserva }
               );
            modelBuilder.Entity<Reserva>().HasData(
               new Reserva { Id = 1, ClienteId = 1, CantidadPersonas = 4, Fecha = DateTime.Now/*Esto hay que ponerlo en un rango de horas (23,0,2,1) o algo así*/},
               new Reserva { Id = 2, ClienteId = 2, CantidadPersonas = 2, Fecha = new DateTime(2023, 10, 25, 18, 0, 0) }
               );
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, Nombre = "Juan Perez", Telefono = "1234567890", Email = "juan.perez@example.com" },
                new Cliente { Id = 2, Nombre = "Maria Gomez", Telefono = "0987654321", Email = "maria.gomez@example.com" }
                );
            modelBuilder.Entity<ListaDeEspera>().HasData(
               new ListaDeEspera { Id = 1, ClienteId = 1, CantidadPersonas = 4, Estado = EstadoListaEspera.Esperando },
               new ListaDeEspera { Id = 2, ClienteId = 2, CantidadPersonas = 2, Estado = EstadoListaEspera.Finalizado }
               );


        }
    }

}