namespace Proyecto_Progra_II.Entities
{
    public class Reservas
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int CantidadPersonas { get; set; }

        public int ClienteId { get; set; }
        public int MesaId { get; set; }
        public int EstadoReservaId { get; set; }
    }
}
