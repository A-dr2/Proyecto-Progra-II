using Microsoft.AspNetCore.Mvc;
using Proyecto_Progra_II.Entities;
using Proyecto_Progra_II.Services.Interfaces;

namespace Proyecto_Progra_II.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoMesaController : ControllerBase
    {
        private readonly IEstadoMesaServices _estadoServices;

        public EstadoMesaController(IEstadoMesaServices estadoServices)
        {
            _estadoServices = estadoServices;
        }

        // GET: api/EstadoMesa
        [HttpGet]
        public IEnumerable<EstadoMesa> Get()
        {
            return _estadoServices.GetAll();
        }

        // GET: api/EstadoMesa/bloqueosActuales
        [HttpGet("bloqueosActuales")]
        public IEnumerable<EstadoMesa> GetBloqueosActuales()
        {
            return _estadoServices.GetBloqueosActuales();
        }

        // GET: api/EstadoMesa/5
        [HttpGet("{id}")]
        public EstadoMesa Get(int id)
        {
            return _estadoServices.GetById(id);
        }

        // POST: api/EstadoMesa
        [HttpPost]
        public EstadoMesa Post([FromBody] EstadoMesa estado)
        {
            return _estadoServices.Create(estado);
        }
    }
}