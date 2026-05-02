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

        public List<Mesa> GetAll()
        {
            return _context.Mesas
                .Include(m => m.Zona)
                .Include(m => m.EstadoMesa)
                .ToList();
        }

        public Mesa GetById(int id)
        {
            return _context.Mesas
                .Include(m => m.Zona)
                .Include(m => m.EstadoMesa)
                .FirstOrDefault(m => m.Id == id)
                ?? throw new KeyNotFoundException("Mesa no encontrada");
        }

        public List<Mesa> GetByZona(int zonaId)
        {
            return _context.Mesas
                .Include(m => m.Zona)
                .Include(m => m.EstadoMesa)
                .Where(m => m.ZonaId == zonaId)
                .ToList();
        }

        public Mesa Create(Mesa mesa)
        {
            _context.Mesas.Add(mesa);
            _context.SaveChanges();
            return mesa;
        }

        public bool EstaDisponible(int mesaId)
        {
            var mesa = GetById(mesaId);
            return mesa.EstadoMesa?.TipoBloqueo == TipoBloqueo.Disponible;
        }

        public void CambiarEstado(int mesaId, int estadoId)
        {
            var mesa = GetById(mesaId);
            mesa.EstadoMesaId = estadoId;
            _context.SaveChanges();
        }
    }
}