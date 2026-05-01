using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IMesasServices
    {
        public List<Mesa> GetAllMesas();
        public Mesa GetMesaById(int id);
        public Mesa AgregarMesas(Mesa mesa);
        public Mesa ActualizarMesas(int id, Mesa mesa);
        public void EliminarMesas(int id);
        public string ObtenerEstadoMesa(int id);

    }
}
