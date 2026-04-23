using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IEstadoMesaServices
    {
        public List<EstadoMesa> GetAllBloqueoMesa();
            public EstadoMesa GetBloqueoMesaById(int id);
            public EstadoMesa CreateBloqueoMesa(EstadoMesa bloqueoMesa);
            public EstadoMesa UpdateBloqueoMesa(int id, EstadoMesa bloqueoMesa);
            public void DeleteBloqueoMesa(int id);
    }
}
