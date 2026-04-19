namespace Proyecto_Progra_II.Entities
{
    public class Zonas
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public List<Mesas> Mesas { get; set; } = new List<Mesas>();
    }
}
