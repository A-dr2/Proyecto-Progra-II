namespace Proyecto_Progra_II.Entities
{
    public class EstadoMesa
    {
        public int Id { get; set; }
        public int EstadoMesaId { get; set; }
        public int MesaId { get; set; }
        public Mesa Mesa { get; set; } = null!;

        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string? Motivo { get; set; }

        public TipoBloqueo TipoBloqueo { get; set; }
    }
    public enum TipoBloqueo
    {
        Disponible,
        Mantenimiento,
        EventoEspecial,
        Reserva
    }
        
}