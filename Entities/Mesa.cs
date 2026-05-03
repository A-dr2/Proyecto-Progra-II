namespace Proyecto_Progra_II.Entities
{
    public class Mesa
    {
        public int Id { get; set; }
        public int Capacidad { get; set; }

        public int ZonaId { get; set; }
        public Zona? Zona { get; set; }

        public int EstadoMesaId { get; set; }
        public EstadoMesa? EstadoMesa { get; set; }

        // Relación muchos a muchos con Reserva
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();
    }

    public class MesaDto
    {
        public int Id { get; set; }
        public int Capacidad { get; set; }
        public int ZonaId { get; set; }
        public int EstadoMesaId { get; set; }
    }
}