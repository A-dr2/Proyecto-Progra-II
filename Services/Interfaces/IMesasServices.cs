using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IMesaServices
    {
        public List<Mesa> GetAll();
        public Mesa GetById(int id);
        public List<Mesa> GetByZona(int zonaId);
        public Mesa Create(Mesa mesa);
        public bool EstaDisponible(int mesaId);
        public void CambiarEstado(int mesaId, int estadoId);
    }
}