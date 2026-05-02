namespace Proyecto_Progra_II.Entities
{
    public class ListaDeEspera
    {
        public int Id { get; set; }
        public DateTime FechaSolicitud { get; set; } = DateTime.Now;
        public int CantidadPersonas { get; set; }
        public EstadoListaEspera Estado { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }

    public class ListaDeEsperaDto
    {
        public int Id { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int CantidadPersonas { get; set; }
        public EstadoListaEspera Estado { get; set; }
        public int ClienteId { get; set; }
    }

    public enum EstadoListaEspera
    {
        Esperando,
        Finalizado,
        Cancelado,
        NoAsistio
    }
}