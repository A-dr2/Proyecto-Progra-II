using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IMesaServices
    {
        public List<MesaDto> GetAll();
        public MesaDto GetById(int id);
        public List<MesaDto> GetByZona(int zonaId);
        public MesaDto Create(MesaDto mesa);
        public bool EstaDisponible(int mesaId);
        public void CambiarEstado(int mesaId, int estadoId);
    }
}