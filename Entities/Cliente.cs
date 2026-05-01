namespace Proyecto_Progra_II.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Telefono { get; set; }
        public string? Email { get; set; }
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
