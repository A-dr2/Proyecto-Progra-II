using Microsoft.AspNetCore.Mvc;
using Proyecto_Progra_II.Dtos.MesaDtos;
using Proyecto_Progra_II.Entities;
using Proyecto_Progra_II.Services.Interfaces;

namespace Proyecto_Progra_II.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private readonly IMesaServices _mesaServices;

        public MesaController(IMesaServices mesaServices)
        {
            _mesaServices = mesaServices;
        }

        // 🔹 GET: api/mesa
        [HttpGet]
        public IEnumerable<MesaDTO> Get()
        {
            return _mesaServices.GetAllMesas().Select(m => new MesaDTO
            {
                Id = m.Id,
                Capacidad = m.Capacidad,
                ZonaId = m.ZonaId,
                Estado = m.EstadoMesa.Nombre,
                ObservacionEstado = m.ObservacionEstado
            });
        }

        // 🔹 GET: api/mesa/5
        [HttpGet("{id}")]
        public MesaDTO Get(int id)
        {
            var m = _mesaServices.GetMesaById(id);

            return new MesaDTO
            {
                Id = m.Id,
                Capacidad = m.Capacidad,
                ZonaId = m.ZonaId,
                Estado = m.EstadoMesa.Nombre,
                ObservacionEstado = m.ObservacionEstado
            };
        }

        // 🔹 POST: api/mesa
        [HttpPost]
        public MesaDTO Post([FromBody] CrearMesaDto dto)
        {
            var mesa = new Mesa
            {
                Capacidad = dto.Capacidad,
                ZonaId = dto.ZonaId
            };

            var result = _mesaServices.CreateMesa(mesa);

            return new MesaDTO
            {
                Id = result.Id,
                Capacidad = result.Capacidad,
                ZonaId = result.ZonaId,
                Estado = result.EstadoMesa.Nombre,
                ObservacionEstado = result.ObservacionEstado
            };
        }

        // 🔹 PUT: api/mesa/5
        [HttpPut("{id}")]
        public MesaDTO Put(int id, [FromBody] CrearMesaDto dto)
        {
            var mesa = new Mesa
            {
                Capacidad = dto.Capacidad,
                ZonaId = dto.ZonaId
            };

            var result = _mesaServices.UpdateMesa(id, mesa);

            return new MesaDTO
            {
                Id = result.Id,
                Capacidad = result.Capacidad,
                ZonaId = result.ZonaId,
                Estado = result.EstadoMesa.Nombre,
                ObservacionEstado = result.ObservacionEstado
            };
        }

        // 🔹 GET: api/mesa/disponible/5
        [HttpGet("disponible/{mesaId}")]
        public bool Disponible(int mesaId)
        {
            return _mesaServices.EstaDisponible(mesaId);
        }

        // 🔹 POST: api/mesa/estado/5
        [HttpPost("estado/{mesaId}")]
        public void CambiarEstado(int mesaId, [FromBody] CambiarEstadoDTO dto)
        {
            _mesaServices.CambiarEstado(mesaId, dto.EstadoId, dto.Motivo);
        }

        // 🔹 GET: api/mesa/zona/1
        [HttpGet("zona/{zonaId}")]
        public IEnumerable<MesaDTO> GetByZona(int zonaId)
        {
            return _mesaServices.GetAllMesas()
                .Where(m => m.ZonaId == zonaId)
                .Select(m => new MesaDTO
                {
                    Id = m.Id,
                    Capacidad = m.Capacidad,
                    ZonaId = m.ZonaId,
                    Estado = m.EstadoMesa.Nombre,
                    ObservacionEstado = m.ObservacionEstado
                });
        }
    }
}