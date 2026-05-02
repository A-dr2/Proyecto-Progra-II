using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IMesaServices
    {
        public List<Mesa> GetAllMesas();
        public Mesa GetMesaById(int id);
        public Mesa CrearMesa(Mesa mesa);

        public bool EstaDisponible(int mesaId);

        public void CambiarEstado(int mesaId, int estadoId, string? motivo = null);
    }
}