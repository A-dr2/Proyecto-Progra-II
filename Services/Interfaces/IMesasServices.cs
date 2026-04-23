using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IMesasServices
    {
        public List<Mesa> GetMesas();
        public Mesa GetMesaById(int id);
        public Mesa CreateMesa(Mesa mesa);
        public Mesa UpdateMesa(int id, Mesa mesa);
        public void DeleteMesa(int id);
    }
}
