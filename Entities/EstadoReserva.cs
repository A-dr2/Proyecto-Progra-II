namespace Proyecto_Progra_II.Entities
{
    public class EstadoReserva
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public List<Reserva> Reservas { get; set; } = null!;
    }
}
