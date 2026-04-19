namespace Proyecto_Progra_II.Entities
{
    public class Mesas
    {
        public int Id { get; set; }
        public int Capacidad { get; set; }
        public int ZonaId { get; set; }

        public List<Reservas> Reservas { get; set; } = null!;
        public List<BloqueoMesa> Bloqueos { get; set; } = null!;
    }
}
