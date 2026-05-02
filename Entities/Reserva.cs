namespace Proyecto_Progra_II.Entities
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int CantidadPersonas { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public EstadoReserva EstadoReserva { get; set; }
    }

    public class ReservaDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int CantidadPersonas { get; set; }
        public int ClienteId { get; set; }
        public EstadoReserva EstadoReserva { get; set; }
    }
}