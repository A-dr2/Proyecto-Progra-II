using Proyecto_Progra_II.Entities;
using Proyecto_Progra_II.Services.Interfaces;

namespace Proyecto_Progra_II.Services
{
    public class MesaServices : IMesaServices
    {
        

        // 🔹 Mesas simuladas
        private static List<Mesa> _mesas = new List<Mesa>()
        {
            new Mesa
            {
                Id = 1, Capacidad = 4, ZonaId = 1,
                EstadoMesaId = 1,
                EstadoMesa = _estados.First(e => e.Id == 1)
            },
            new Mesa
            {
                Id = 2, Capacidad = 2, ZonaId = 1,
                EstadoMesaId = 3,
                EstadoMesa = _estados.First(e => e.Id == 3),
                ObservacionEstado = "Pata rota"
            }
        };

        // 🔹 GET ALL
        public List<Mesa> GetAllMesas()
        {
            return _mesas;
        }

        // 🔹 GET BY ID
        public Mesa GetMesaById(int id)
        {
            var mesa = _mesas.FirstOrDefault(m => m.Id == id);

            if (mesa == null)
                throw new Exception("Mesa no encontrada");

            return mesa;
        }

        // 🔹 CREATE
        public Mesa CreateMesa(Mesa mesa)
        {
            mesa.Id = _mesas.Count + 1;

            // por defecto disponible
            var estado = _estados.First(e => e.Id == 1);

            mesa.EstadoMesaId = estado.Id;
            mesa.EstadoMesa = estado;

            _mesas.Add(mesa);
            return mesa;
        }

        // 🔹 UPDATE (solo datos básicos)
        public Mesa UpdateMesa(int id, Mesa mesa)
        {
            var existente = GetMesaById(id);

            existente.Capacidad = mesa.Capacidad;
            existente.ZonaId = mesa.ZonaId;

            return existente;
        }

        // 🔹 DISPONIBILIDAD
        public bool EstaDisponible(int mesaId)
        {
            var mesa = GetMesaById(mesaId);

            return mesa.EstadoMesaId == 1; // Disponible
        }

        // 🔹 CAMBIAR ESTADO (con mensaje opcional)
        public void CambiarEstado(int mesaId, int estadoId, string? motivo = null)
        {
            var mesa = GetMesaById(mesaId);

            var estado = _estados.FirstOrDefault(e => e.Id == estadoId);

            if (estado == null)
                throw new Exception("Estado no válido");

            mesa.EstadoMesaId = estado.Id;
            mesa.EstadoMesa = estado;

            mesa.ObservacionEstado = motivo;
        }
    }
}