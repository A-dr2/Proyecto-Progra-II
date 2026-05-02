using Microsoft.AspNetCore.Mvc;
using Proyecto_Progra_II.Entities;
using Proyecto_Progra_II.Services.Interfaces;

namespace Proyecto_Progra_II.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonaController : ControllerBase
    {
        private readonly IZonasServices _zonasServices;

        public ZonaController(IZonasServices zonasServices)
        {
            _zonasServices = zonasServices;
        }

        // GET: api/Zona
        [HttpGet]
        public IEnumerable<ZonaDto> Get()
        {
            return _zonasServices.GetAll();
        }

        // GET: api/Zona/mesas
        [HttpGet("mesas")]
        public IEnumerable<ZonaMesasDto> GetWithMesas()
        {
            return _zonasServices.GetAllWithMesas();
        }

        // GET: api/Zona/5
        [HttpGet("{id}")]
        public Zona Get(int id)
        {
            return _zonasServices.GetById(id);
        }

        // POST: api/Zona
        [HttpPost]
        public Zona Post([FromBody] Zona zona)
        {
            return _zonasServices.Create(zona);
        }
    }
}