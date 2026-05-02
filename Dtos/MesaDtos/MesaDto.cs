using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Dtos.MesaDtos
{
    public class MesaDTO
    {
        public int Id { get; set; }
        public int Capacidad { get; set; }
        public int ZonaId { get; set; }
        public EstadoMesa Estado { get; set; } = null!;

       
    }
}
