using Microsoft.EntityFrameworkCore;
using Proyecto_Progra_II.Entities;
using Proyecto_Progra_II.MiDbContext;
using Proyecto_Progra_II.Services.Interfaces;

namespace Proyecto_Progra_II.Services
{
    public class ListaDeEsperaServices : IListaDeEsperaServices
    {
        private readonly MyAppDbContext _context;

        public ListaDeEsperaServices(MyAppDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public List<ListaDeEspera> GetAll()
        {
            return _context.ListasDeEspera
                .Include(l => l.Cliente)
                .OrderBy(l => l.FechaSolicitud)
                .ToList();
        }

        public ListaDeEspera AgregarALista(Reserva reserva)
        {
            var lista = new ListaDeEspera
            {
                ClienteId = reserva.ClienteId,
                CantidadPersonas = reserva.CantidadPersonas,
                FechaSolicitud = DateTime.Now,
                Estado = EstadoListaEspera.Esperando
            };

            _context.ListasDeEspera.Add(lista);
            _context.SaveChanges();

            return _context.ListasDeEspera
                .Include(l => l.Cliente)
                .FirstOrDefault(l => l.Id == lista.Id)!;
        }

        public Reserva? ObtenerSiguiente()
        {
            var siguiente = _context.ListasDeEspera
                .Include(l => l.Cliente)
                .Where(l => l.Estado == EstadoListaEspera.Esperando)
                .OrderBy(l => l.FechaSolicitud)
                .FirstOrDefault();

            if (siguiente == null) return null;

            siguiente.Estado = EstadoListaEspera.Finalizado;

            var reserva = new Reserva
            {
                ClienteId = siguiente.ClienteId,
                CantidadPersonas = siguiente.CantidadPersonas,
                Fecha = DateTime.Now,
                EstadoReserva = EstadoReserva.Pendiente
            };

            _context.SaveChanges();
            return reserva;
        }
    }
}