namespace Proyecto_Progra_II.Entities
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int CantidadPersonas { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public EstadoReserva EstadoReserva { get; set; }

        // Relación muchos a muchos con Mesa
        public List<Mesa> Mesas { get; set; } = new List<Mesa>();
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