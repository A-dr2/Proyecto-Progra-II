using Proyecto_Progra_II.Entities;
using Proyecto_Progra_II.MiDbContext;
using Proyecto_Progra_II.Services.Interfaces;

namespace Proyecto_Progra_II.Services
{
    public class ZonaServices : IZonaServices
    {
        private readonly MyAppDbContext _context;

        public ZonaServices(MyAppDbContext context)
        {
            _context = context;
        }

        // GET: todas las zonas
        public List<Zona> GetAllZonas()
        {
            return _context.Zonas.ToList();
        }

        // GET: zona por id
        public Zona GetZonaById(int id)
        {
            return _context.Zonas.FirstOrDefault(zona => zona.Id == id)
                ?? throw new KeyNotFoundException("Zona con no encontrada");
        }

        // POST: crear zona
        public Zona CreateZona(Zona zona)
        {
            _context.Zonas.Add(zona);
            _context.SaveChanges();
            return zona;
        }

        // PUT: actualizar zona
        public Zona UpdateZona(int id, Zona zona)
        {
            var zonaExistente = GetZonaById(id);
            zonaExistente.Nombre = zona.Nombre;
            _context.SaveChanges();
            return zonaExistente;
        }

        // DELETE: eliminar zona
        public void DeleteZona(int id)
        {
            var zona = GetZonaById(id);
            _context.Zonas.Remove(zona);
            _context.SaveChanges();
        }
    }
}