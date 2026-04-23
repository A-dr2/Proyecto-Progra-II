namespace Proyecto_Progra_II.Entities
{
    public class Turno
    {
        public int Id { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        public List<Reserva> Reservas { get; set; } = null!;
    }
}
