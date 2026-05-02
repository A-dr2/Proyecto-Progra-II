using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IZonasServices
    {
        public List<ZonaDto> GetAll();
        public List<ZonaMesasDto> GetAllWithMesas();
        public Zona GetById(int id);
        public Zona Create(Zona zona);
    }
}