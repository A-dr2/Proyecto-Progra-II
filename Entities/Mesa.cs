namespace Proyecto_Progra_II.Entities
{
    public class Mesa
    {
        public int Id { get; set; }
        public int Capacidad { get; set; }
        public int ZonaId { get; set; }

        public int EstadoMesaId { get; set; }


        public ICollection<ReservaMesa> ReservaMesas { get; set; } = new List<ReservaMesa>();
        public List<EstadoMesa> Estados { get; set; } = null!;
        public Zona Zona { get; set; } = null!;
    }
}
