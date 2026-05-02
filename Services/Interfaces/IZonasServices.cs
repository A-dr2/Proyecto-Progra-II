using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IZonasServices
    {
        public List<Zonas> GetZonas();
        public Zonas GetZonaById(int id);
        public Zonas CreateZona(Zonas zona);
        public Zonas UpdateZona(int id, Zonas zona);
        public void DeleteZona(int id);
    }
}
