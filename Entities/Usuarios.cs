namespace Proyecto_Progra_II.Entities
{
    public class Usuarios
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public List<Reservas> Reservas { get; set; } = null!;
    }
}
