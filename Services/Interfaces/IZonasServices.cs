using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IZonasServices
    {
        public List<Zona> GetZonas();
        public Zona GetZonaById(int id);
        public Zona CreateZona(Zona zona);
        public Zona UpdateZona(int id, Zona zona);
        public void DeleteZona(int id);
    }
}
