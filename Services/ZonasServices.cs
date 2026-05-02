using Proyecto_Progra_II.Entities;
using Proyecto_Progra_II.MiDbContext;
using Proyecto_Progra_II.Services.Interfaces;

namespace Proyecto_Progra_II.Services
{
    public class ZonasServices : IZonasServices
    {
        private readonly MyAppDbContext _context;

        public ZonasServices(MyAppDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public List<ZonaDto> GetAll()
        {
            return _context.Zonas
                .Select(z => new ZonaDto { Id = z.Id, Nombre = z.Nombre })
                .ToList();
        }

        public List<ZonaMesasDto> GetAllWithMesas()
        {
            return _context.Zonas
                .Select(z => new ZonaMesasDto
                {
                    Nombre = z.Nombre,
                    Mesas = z.Mesas.Select(m => new MesaDto
                    {
                        Id = m.Id,
                        Capacidad = m.Capacidad,
                        ZonaId = m.ZonaId,
                        EstadoMesaId = m.EstadoMesaId
                    }).ToList()
                }).ToList();
        }

        public Zona GetById(int id)
        {
            return _context.Zonas.FirstOrDefault(z => z.Id == id)
                ?? throw new KeyNotFoundException("Zona no encontrada");
        }

        public Zona Create(Zona zona)
        {
            _context.Zonas.Add(zona);
            _context.SaveChanges();
            return zona;
        }
    }
}