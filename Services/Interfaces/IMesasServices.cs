using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IMesasServices
    {
        public List<Mesas> GetMesas();
        public Mesas GetMesaById(int id);
        public Mesas CreateMesa(Mesas mesa);
        public Mesas UpdateMesa(int id, Mesas mesa);
        public void DeleteMesa(int id);
    }
}
