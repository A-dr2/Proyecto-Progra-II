using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IMesaServices
    {
        List<Mesa> GetAllMesas();
        Mesa GetMesaById(int id);
        Mesa CreateMesa(Mesa mesa);
        Mesa UpdateMesa(int id, Mesa mesa);

        bool EstaDisponible(int mesaId);

        void CambiarEstado(int mesaId, int estadoId, string? motivo = null);
    }
}