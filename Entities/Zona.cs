namespace Proyecto_Progra_II.Entities
{
    public class Zona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<Mesa> Mesas { get; set; }
    }

    public class ZonaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class ZonaMesasDto
    {
        public string Nombre { get; set; }
        public List<MesaDto> Mesas { get; set; }
    }
}