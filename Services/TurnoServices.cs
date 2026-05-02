using Proyecto_Progra_II.Entities;
using Proyecto_Progra_II.MiDbContext;
using Proyecto_Progra_II.Services.Interfaces;

namespace Proyecto_Progra_II.Services
{
    public class TurnoServices : ITurnoServices
    {
        private readonly MyAppDbContext _context;

        public TurnoServices(MyAppDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public List<Turno> GetAll()
        {
            return _context.Turnos.ToList();
        }

        public Turno GetById(int id)
        {
            return _context.Turnos.FirstOrDefault(t => t.Id == id)
                ?? throw new KeyNotFoundException("Turno no encontrado");
        }
    }
}