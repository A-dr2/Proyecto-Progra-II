namespace Proyecto_Progra_II.Entities
{
    public class TurnoReserva
    {
        public int ReservaId { get; set; }
        public Reserva Reserva { get; set; } = null!;
        public int TurnoId { get; set; }
        public Turno Turno { get; set; } = null!;

    }
}
