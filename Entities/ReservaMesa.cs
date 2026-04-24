namespace Proyecto_Progra_II.Entities
{
    public class ReservaMesa
    {
        public int ReservaId { get; set; }
        public Reserva Reserva { get; set; } = null!;

        public int MesaId { get; set; }
        public Mesa Mesa { get; set; } = null!;
    }
}
