using Proyecto_Progra_II.Entities;
using Proyecto_Progra_II.MiDbContext;
using Proyecto_Progra_II.Services.Interfaces;

namespace Proyecto_Progra_II.Services
{
    public class ReservasServices : IReservaServices
    {
        private readonly MyAppDbContext _context;

        private readonly IListaDeEsperaServices _listaEsperaService;

        public ReservasServices(MyAppDbContext context, IListaDeEsperaServices listaEsperaService)
        {
            _context = context;
            _listaEsperaService = listaEsperaService;
        }

        public bool VerificarDuplicado(Reserva reserva)
        {
            // => Funcion lambda
            return _context.Reservas.Any(_reserva =>
                _reserva.ClienteId == reserva.ClienteId &&
                _reserva.Fecha == reserva.Fecha &&
                _reserva.EstadoReserva != EstadoReserva.Cancelada);
        }
        private bool VerificarDisponibilidad(Reserva reserva)
        {
            int totalMesas = _context.Mesas.Count();

            int reservasEnEseMomento = _context.Reservas
                .Count(r => r.Fecha == reserva.Fecha &&
                            r.EstadoReserva != EstadoReserva.Cancelada);

            return reservasEnEseMomento < totalMesas;
        }
        public void LiberarCupo()
        {
            var siguienteReserva = _listaEsperaService.ObtenerSiguiente();

            if (siguienteReserva != null)
            {
                _context.Reservas.Add(siguienteReserva);
                _context.SaveChanges();
            }
        }
        //Antes de crear reserva // Evita duplicados
        public Reserva? CrearReserva(Reserva reserva)
        {
            if (VerificarDuplicado(reserva))
                throw new InvalidOperationException("Reserva Duplicada");

            bool hayDisponibilidad = VerificarDisponibilidad(reserva);

            if (hayDisponibilidad)
            {
                _context.Reservas.Add(reserva);
                _context.SaveChanges();
                return reserva;
            }
            else
            {
                //añade a lista de espera
                _listaEsperaService.AgregarALista(reserva);
                return null;
            }
        }

        public void DeleteReserva(int id)
        {
            var reserva = GetReservaById(id);
            _context.Reservas.Remove(reserva);
            _context.SaveChanges();
        }

        public Reserva GetReservaById(int id)
        {
            return _context.Reservas.FirstOrDefault(reserva => reserva.Id == id)
                ?? throw new KeyNotFoundException("Reserva no encontrada");
        }

        public List<Reserva> GetReservas()
        {
            return _context.Reservas.ToList();
        }

        public Reserva UpdateReserva(int id, Reserva reserva)
        {
            var reservaExistente = GetReservaById(id);
            reservaExistente.Fecha = reserva.Fecha;
            reservaExistente.CantidadPersonas = reserva.CantidadPersonas;
            reservaExistente.ClienteId = reserva.ClienteId;
            reservaExistente.EstadoReserva = reserva.EstadoReserva;
            _context.SaveChanges();
            return reservaExistente;
        }

    }
}