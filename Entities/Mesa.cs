namespace Proyecto_Progra_II.Entities
{
    public class Mesa
    {
        public int Id { get; set; }
        public int Capacidad { get; set; }
        public int ZonaId { get; set; }

        public List<Reserva> Reservas { get; set; } = null!;
        public List<EstadoMesa> Bloqueos { get; set; } = null!;
    }
}
