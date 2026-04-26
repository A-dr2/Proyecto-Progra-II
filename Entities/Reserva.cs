namespace Proyecto_Progra_II.Entities
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int CantidadPersonas { get; set; }

        public int ClienteId { get; set; }
        public int ListaDeEsperaId { get; set; }

        public Cliente Cliente { get; set; } = null!;
        public ListaDeEspera ListaDeEspera { get; set; } = null!;
        public ICollection<ReservaMesa> ReservaMesas { get; set; } = new List<ReservaMesa>();
        public ICollection<TurnoReserva> TurnoReservas { get; set; } = new List<TurnoReserva>();

        public enum EstadoReserva
        {
            Confirmada,
            Pendiente,
            Cancelada
        }

    }
}
