namespace Proyecto_Progra_II.Entities
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int CantidadPersonas { get; set; }

        public int ClienteId { get; set; }
        public int? ListaDeEsperaId { get; set; }

        public Cliente Cliente { get; set; } = null!;
        public ListaDeEspera? ListaDeEspera { get; set; } = null!;
       public ICollection<Mesa> Mesas { get; set; } = new List<Mesa>();

        public int EstadoReservaId { get; set; }
        public EstadoReserva EstadoReserva { get; set; }
    }
}
