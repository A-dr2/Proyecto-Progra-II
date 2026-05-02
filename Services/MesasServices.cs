using Proyecto_Progra_II.Entities;
using Proyecto_Progra_II.MiDbContext;
using Proyecto_Progra_II.Services.Interfaces;

namespace Proyecto_Progra_II.Services
{
    public class MesaServices : IMesaServices
    {
        private readonly MyAppDbContext _mesas;
        private readonly IEstadoMesaServices _estadoMesaServices;

        public MesaServices(MyAppDbContext mesa, IEstadoMesaServices estadoMesaServices)
        {
            _mesas = mesa;
            _estadoMesaServices = estadoMesaServices;
        }

        // 🔹 GET ALL
        public List<Mesa> GetAllMesas()
        {
            return _mesas.Mesas.ToList();
        }

        // 🔹 GET BY ID
        public Mesa GetMesaById(int id)
        {
            var mesa = _mesas.Mesas.FirstOrDefault(m => m.Id == id);

            if (mesa == null)
                throw new Exception("Mesa no encontrada");

            return mesa;
        }

        // 🔹 CREATE
        public Mesa CrearMesa(Mesa mesa)
        {
            mesa.EstadoMesaId = 1; // Disponible por defecto
            _mesas.Mesas.Add(mesa);
            _mesas.SaveChanges();

            return mesa;
        }



        // 🔹 DISPONIBILIDAD
        public bool EstaDisponible(int mesaId)
        {
            var mesa = GetMesaById(mesaId);

            // 1. Estado lógico
            if (mesa.EstadoMesaId != 1)
                return false;

            // 2. Bloqueos por tiempo
            var ahora = DateTime.Now;

            var bloqueos = _mesas.EstadosMesa
                .Where(b => b.MesaId == mesaId)
                .ToList();

            var tieneBloqueoActivo = bloqueos.Any(b =>
                b.FechaInicio <= ahora &&
                b.FechaFin >= ahora
            );

            return !tieneBloqueoActivo;
        }

        // 🔹 CAMBIAR ESTADO (con mensaje opcional)
        public void CambiarEstado(int mesaId, int estadoId, string? motivo = null)
        {
            var mesa = GetMesaById(mesaId);

            mesa.EstadoMesaId = estadoId;

            _mesas.SaveChanges();
        }
    }
}