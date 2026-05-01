namespace Proyecto_Progra_II.Dtos.MesaDtos
{
    public class CambiarEstadoDTO
    {
        public int EstadoId { get; set; }     // Id del estado (ej: 1,2,3,4)
        public string? Motivo { get; set; }   // mensaje opcional
    }
}
