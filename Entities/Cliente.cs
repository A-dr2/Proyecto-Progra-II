namespace Proyecto_Progra_II.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();
    }

    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }

    public class ClienteReservasDto
    {
        public string Nombre { get; set; }
        public List<ReservaDto> Reservas { get; set; }
    }
}