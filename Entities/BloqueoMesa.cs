namespace Proyecto_Progra_II.Entities
{
    public class BloqueoMesa
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public required string Motivo { get; set; }

        public int MesaId { get; set; }
    }
}
