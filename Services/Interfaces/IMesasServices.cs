using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IMesasServices
    {
        public List<Mesas> GetAllMesas();
        public Mesas GetMesaById(int id);
        public Mesas AgregarMesas(Mesas mesa);
        public Mesas ActualizarMesas(int id, Mesas mesa);
        public void EliminarMesas(int id);
        public string ObtenerEstadoMesa(int id);

    }
}
