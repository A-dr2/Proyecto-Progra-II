namespace Proyecto_Progra_II.Entities
{
    public class EstadoMesa
    {
        public int Id { get; set; }
        public enum TipoBloqueo
        {
            Mantenimiento,
            EventoEspecial,
            Reserva
        }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public required string Motivo { get; set; }

        public int MesaId { get; set; }

        public List<ListaDeEspera> ListasDeEspera { get; set; } = null!;
        public List<Mesa> Mesas { get; set; } = null!;  
    }
}
