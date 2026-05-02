namespace Proyecto_Progra_II.Entities
{
    public class ListaDeEspera
    {
        public int Id { get; set; }

        public DateTime FechaSolicitud { get; set; } = DateTime.Now;

        public int CantidadPersonas { get; set; }

        // Estado para saber qué pasó con este turno
        public EstadoListaEspera Estado { get; set; }

        public string? Comentarios { get; set; }

        // Relación con Cliente
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; } = null!;
        public Reserva Reserva { get; set; } = null!;

    }

    public enum EstadoListaEspera
    {
        Esperando,
        Finalizado, // Ya se le asignó mesa
        Cancelado,  // El cliente se fue
        NoAsistio   // Se le llamó y no apareció
    }
        
}