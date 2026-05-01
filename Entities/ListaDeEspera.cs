namespace Proyecto_Progra_II.Entities
{
    public class ListaDeEspera
    {
        public int Id { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public Reserva Reserva { get; set; } = null!;
    }
}
