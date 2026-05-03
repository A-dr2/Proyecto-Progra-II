using Microsoft.EntityFrameworkCore;
using Proyecto_Progra_II.Entities;
using Proyecto_Progra_II.MiDbContext;
using Proyecto_Progra_II.Services.Interfaces;

namespace Proyecto_Progra_II.Services
{
    public class MesasServices : IMesaServices
    {
        private readonly MyAppDbContext _context;

        public MesasServices(MyAppDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public List<MesaDto> GetAll()
        {
            return _context.Mesas
                .Include(m => m.Zona)
                .Include(m => m.EstadoMesa)
                .Select(m => new MesaDto
                {
                    Id = m.Id,
                    Capacidad = m.Capacidad,
                    ZonaId = m.ZonaId,
                    EstadoMesaId = m.EstadoMesaId
                })
                .ToList();
        }
        public MesaDto GetById(int id)
        {
            return _context.Mesas
                .Include(m => m.Zona)
                .Include(m => m.EstadoMesa)
                .Where(m => m.Id == id)
                .Select(m => new MesaDto
                {
                    Id = m.Id,
                    Capacidad = m.Capacidad,
                    ZonaId = m.ZonaId,
                    EstadoMesaId = m.EstadoMesaId
                })
                .FirstOrDefault() ?? throw new KeyNotFoundException("Mesa no encontrada");
        }

        public List<MesaDto> GetByZona(int zonaId)
        {
            return _context.Mesas
                .Where(m => m.ZonaId == zonaId)
                .Select(m => new MesaDto
                {
                    Id = m.Id,
                    Capacidad = m.Capacidad,
                    ZonaId = m.ZonaId,
                    EstadoMesaId = m.EstadoMesaId
                })
                .ToList();
        }

        public MesaDto Create(MesaDto mesa)
        {
           _context.Mesas.Add(new Mesa
            {
                Capacidad = mesa.Capacidad,
                ZonaId = mesa.ZonaId,
                EstadoMesaId = mesa.EstadoMesaId
            });
            _context.SaveChanges();
            return mesa;
        }

        public bool EstaDisponible(int mesaId)
        {
            var mesa = _context.Mesas
                .Include(m => m.EstadoMesa)
                .FirstOrDefault(m => m.Id == mesaId) ?? throw new KeyNotFoundException("Mesa no encontrada");
            return mesa.EstadoMesa?.TipoBloqueo == TipoBloqueo.Disponible;
        }

        public void CambiarEstado(int mesaId, int estadoId)
        {
            var mesa = _context.Mesas.FirstOrDefault(m => m.Id == mesaId)
                ?? throw new KeyNotFoundException("Mesa no encontrada");
            mesa.EstadoMesaId = estadoId;
            _context.SaveChanges();
        }
    }
}