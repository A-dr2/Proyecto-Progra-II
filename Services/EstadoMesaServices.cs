using Proyecto_Progra_II.Entities;
using Proyecto_Progra_II.Services.Interfaces;
using Proyecto_Progra_II.MiDbContext;

namespace Proyecto_Progra_II.Services
{
    public class EstadoMesaServices : IEstadoMesaServices
    {
        
        private readonly MyAppDbContext _context;

        public EstadoMesaServices(MyAppDbContext context)
        {
            _context = context;
        }

        public EstadoMesa CreateBloqueoMesa(EstadoMesa bloqueoMesa)
        {
            
            if (bloqueoMesa.FechaFin <= bloqueoMesa.FechaInicio)
                throw new ArgumentException("FechaFin debe ser posterior a FechaInicio.");

            _context.EstadosMesa.Add(bloqueoMesa);
            _context.SaveChanges();
            return bloqueoMesa;
        }

        public void DeleteBloqueoMesa(int id)
        {
            var bloqueo = _context.EstadosMesa.Find(id);

            if (bloqueo is null)
                throw new KeyNotFoundException("No existe un bloqueo con Id {id}.");

            _context.EstadosMesa.Remove(bloqueo);
            _context.SaveChanges();
        }

        public List<EstadoMesa> GetAllBloqueoMesa()
        {
            return _context.EstadosMesa.ToList();
        }

        public EstadoMesa GetBloqueoMesaById(int id)
        {
            var bloqueo = _context.EstadosMesa.Find(id);

            if (bloqueo is null)
                throw new KeyNotFoundException("No existe un bloqueo con Id {id}.");

            return bloqueo;
        }

        public EstadoMesa UpdateBloqueoMesa(int id, EstadoMesa bloqueoMesa)
        {
            var existente = _context.EstadosMesa.Find(id);

            if (existente is null)
                throw new KeyNotFoundException("No existe un bloqueo con Id {id}.");

           
            existente.Motivo = bloqueoMesa.Motivo;
            existente.FechaInicio = bloqueoMesa.FechaInicio;
            existente.FechaFin = bloqueoMesa.FechaFin;

            _context.SaveChanges();
            return existente;
        }
    }
}
