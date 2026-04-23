namespace Proyecto_Progra_II.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public List<Reserva> Reservas { get; set; } = null!;
    }
}
