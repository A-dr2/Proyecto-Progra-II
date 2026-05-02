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

        public List<Reserva> GetAll()
        {
            return _context.Reservas.ToList();
        }

        public Reserva GetById(int id)
        {
            return _context.Reservas.FirstOrDefault(r => r.Id == id)
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

        // Verifica si hay mesas libres en esa fecha
        private bool HayMesasDisponibles(DateTime fecha)
        {
            int totalMesas = _context.Mesas.Count();
            int reservasOcupadas = _context.Reservas.Count(r =>
                r.Fecha == fecha &&
                r.EstadoReserva != EstadoReserva.Cancelada);

            return reservasOcupadas < totalMesas;
        }

        public Reserva? Create(Reserva reserva)
        {
            // 1. Validar que esté dentro del horario del turno
            if (!DentroDeTurno(reserva.Fecha))
                throw new InvalidOperationException("La reserva está fuera del horario del turno");

            // 2. Validar que no sea duplicada
            if (EsDuplicada(reserva))
                throw new InvalidOperationException("Reserva duplicada para el mismo cliente y fecha");

            // 3. Si hay mesas disponibles, crear la reserva
            if (HayMesasDisponibles(reserva.Fecha))
            {
                _context.Reservas.Add(reserva);
                _context.SaveChanges();
                return reserva;
            }

            // 4. Si no hay mesas, agregar a lista de espera
            _listaEspera.AgregarALista(reserva);
            return null;
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