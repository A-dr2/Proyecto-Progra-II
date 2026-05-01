namespace Proyecto_Progra_II.Entities
{
    public class Zona
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }

        public ICollection<Mesa> Mesas { get; set; } =  new List<Mesa>();

    }
}
