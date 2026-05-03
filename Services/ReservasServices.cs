using Microsoft.EntityFrameworkCore;
using Proyecto_Progra_II.Entities;
using Proyecto_Progra_II.MiDbContext;
using Proyecto_Progra_II.Services.Interfaces;

namespace Proyecto_Progra_II.Services
{
    public class ReservaServices : IReservaServices
    {
        private readonly MyAppDbContext _context;
        private readonly IListaDeEsperaServices _listaEspera;

        public ReservaServices(MyAppDbContext context, IListaDeEsperaServices listaEspera)
        {
            _context = context;
            _listaEspera = listaEspera;
            _context.Database.EnsureCreated();
        }

        public List<ReservaDto> GetAll()
        {
            return _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Mesas)
                .Select(r => new ReservaDto
                {
                    Id = r.Id,
                    Fecha = r.Fecha,
                    CantidadPersonas = r.CantidadPersonas,
                    ClienteId = r.ClienteId,
                    EstadoReserva = r.EstadoReserva
                })
                .ToList();
        }

        public Reserva GetById(int id)
        {
            return _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Mesas)
                .FirstOrDefault(r => r.Id == id)
                ?? throw new KeyNotFoundException("Reserva no encontrada");
        }

        // Verifica que la hora de la reserva esté dentro del horario del turno
        private bool DentroDeTurno(DateTime fecha)
        {
            var hora = fecha.TimeOfDay;
            return _context.Turnos.Any(t =>
                t.HoraInicio.TimeOfDay <= hora &&
                t.HoraFin.TimeOfDay >= hora);
        }

        // Verifica que no exista una reserva del mismo cliente en la misma fecha
        private bool EsDuplicada(Reserva reserva)
        {
            return _context.Reservas.Any(r =>
                r.ClienteId == reserva.ClienteId &&
                r.Fecha == reserva.Fecha &&
                r.EstadoReserva != EstadoReserva.Cancelada);
        }

        // Busca mesas disponibles que sumen la capacidad necesaria
        private List<Mesa> BuscarMesasDisponibles(DateTime fecha, int cantidadPersonas)
        {
            var mesasOcupadas = _context.Reservas
                .Include(r => r.Mesas)
                .Where(r => r.Fecha == fecha && r.EstadoReserva != EstadoReserva.Cancelada)
                .SelectMany(r => r.Mesas)
                .Select(m => m.Id)
                .ToList();

            var mesasLibres = _context.Mesas
                .Include(m => m.EstadoMesa)
                .Where(m =>
                    !mesasOcupadas.Contains(m.Id) &&
                    m.EstadoMesa.TipoBloqueo == TipoBloqueo.Disponible)
                .OrderBy(m => m.Capacidad)
                .ToList();

            var mesasSeleccionadas = new List<Mesa>();
            int capacidadAcumulada = 0;

            foreach (var mesa in mesasLibres)
            {
                if (capacidadAcumulada >= cantidadPersonas) break;
                mesasSeleccionadas.Add(mesa);
                capacidadAcumulada += mesa.Capacidad;
            }

            if (capacidadAcumulada < cantidadPersonas)
                return new List<Mesa>();

            return mesasSeleccionadas;
        }

        public Reserva? Create(Reserva reserva)
        {
            // 0. Validar que el cliente existe
            var clienteExiste = _context.Clientes.Any(c => c.Id == reserva.ClienteId);
            if (!clienteExiste)
                throw new KeyNotFoundException($"Cliente con id {reserva.ClienteId} no existe");

            // 1. Validar que esté dentro del horario del turno
            if (!DentroDeTurno(reserva.Fecha))
                throw new InvalidOperationException("La reserva está fuera del horario del turno");

            // 2. Validar que no sea duplicada
            if (EsDuplicada(reserva))
                throw new InvalidOperationException("Reserva duplicada para el mismo cliente y fecha");

            // 3. Buscar mesas disponibles con capacidad suficiente
            var mesasDisponibles = BuscarMesasDisponibles(reserva.Fecha, reserva.CantidadPersonas);

            // Si no hay mesas, va a lista de espera
            if (!mesasDisponibles.Any())
            {
                _listaEspera.AgregarALista(reserva);
                return null;
            }

            // Si hay mesas, crea la reserva
            foreach (var mesa in mesasDisponibles)
                reserva.Mesas.Add(mesa);

            _context.Reservas.Add(reserva);
            _context.SaveChanges();

            return _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Mesas)
                .FirstOrDefault(r => r.Id == reserva.Id);
        }

        public Reserva CambiarEstado(int id, EstadoReserva estado)
        {
            var reserva = GetById(id);
            reserva.EstadoReserva = estado;
            _context.SaveChanges();
            return reserva;
        }

        public void LiberarCupo()
        {
            var siguiente = _listaEspera.ObtenerSiguiente();
            if (siguiente != null)
            {
                _context.Reservas.Add(siguiente);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var reserva = GetById(id);
            _context.Reservas.Remove(reserva);
            _context.SaveChanges();
        }
    }
}