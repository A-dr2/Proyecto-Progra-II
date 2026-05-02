using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IBloqueoMesaServices
    {
        public List<BloqueoMesa> GetAllBloqueoMesa();
            public BloqueoMesa GetBloqueoMesaById(int id);
            public BloqueoMesa CreateBloqueoMesa(BloqueoMesa bloqueoMesa);
            public BloqueoMesa UpdateBloqueoMesa(int id, BloqueoMesa bloqueoMesa);
            public void DeleteBloqueoMesa(int id);
    }
}
