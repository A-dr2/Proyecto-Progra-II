using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IEstadoMesaServices
    {
        public List<EstadoMesa> GetAll();
        public List<EstadoMesa> GetBloqueosActuales();
        public EstadoMesa GetById(int id);
        public EstadoMesa Create(EstadoMesa estado);
    }
}