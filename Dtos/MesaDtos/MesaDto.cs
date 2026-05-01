namespace Proyecto_Progra_II.Dtos.MesaDtos
{
    public class MesaDTO
    {
        public int Id { get; set; }
        public int Capacidad { get; set; }
        public int ZonaId { get; set; }

        public string Estado { get; set; } = "";
        public string? ObservacionEstado { get; set; }
    }
}
