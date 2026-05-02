using Microsoft.AspNetCore.Mvc;
using Proyecto_Progra_II.Entities;
using Proyecto_Progra_II.Services.Interfaces;

namespace Proyecto_Progra_II.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private readonly IMesaServices _mesasServices;

        public MesaController(IMesaServices mesasServices)
        {
            _mesasServices = mesasServices;
        }

        // GET: api/Mesa
        [HttpGet]
        public IEnumerable<Mesa> Get()
        {
            return _mesasServices.GetAll();
        }

        // GET: api/Mesa/5
        [HttpGet("{id}")]
        public Mesa Get(int id)
        {
            return _mesasServices.GetById(id);
        }

        // GET: api/Mesa/zona/1
        [HttpGet("zona/{zonaId}")]
        public IEnumerable<Mesa> GetByZona(int zonaId)
        {
            return _mesasServices.GetByZona(zonaId);
        }

        // GET: api/Mesa/disponible/5
        [HttpGet("disponible/{mesaId}")]
        public bool EstaDisponible(int mesaId)
        {
            return _mesasServices.EstaDisponible(mesaId);
        }

        // POST: api/Mesa
        [HttpPost]
        public Mesa Post([FromBody] Mesa mesa)
        {
            return _mesasServices.Create(mesa);
        }

        // PUT: api/Mesa/5/estado/2
        [HttpPut("{mesaId}/estado/{estadoId}")]
        public void CambiarEstado(int mesaId, int estadoId)
        {
            _mesasServices.CambiarEstado(mesaId, estadoId);
        }
    }
}