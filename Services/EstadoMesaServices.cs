using Proyecto_Progra_II.Entities;
using Proyecto_Progra_II.MiDbContext;
using Proyecto_Progra_II.Services.Interfaces;

namespace Proyecto_Progra_II.Services
{
    public class EstadoMesaServices : IEstadoMesaServices
    {
        private readonly MyAppDbContext _context;

        public EstadoMesaServices(MyAppDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public List<EstadoMesa> GetAll()
        {
            return _context.EstadosMesa.ToList();
        }

        public List<EstadoMesa> GetBloqueosActuales()
        {
            var ahora = DateTime.Now;
            return _context.EstadosMesa
                .Where(e =>
                    e.TipoBloqueo != TipoBloqueo.Disponible &&
                    e.FechaInicio.HasValue &&
                    e.FechaFin.HasValue &&
                    e.FechaInicio.Value <= ahora &&
                    e.FechaFin.Value >= ahora)
                .ToList();
        }

        public EstadoMesa GetById(int id)
        {
            return _context.EstadosMesa.FirstOrDefault(e => e.Id == id)
                ?? throw new KeyNotFoundException("Estado no encontrado");
        }

        public EstadoMesa Create(EstadoMesa estado)
        {
            _context.EstadosMesa.Add(estado);
            _context.SaveChanges();
            return estado;
        }
    }
}