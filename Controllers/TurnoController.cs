using Microsoft.AspNetCore.Mvc;
using Proyecto_Progra_II.Entities;
using Proyecto_Progra_II.Services.Interfaces;

namespace Proyecto_Progra_II.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly ITurnoServices _turnoServices;

        public TurnoController(ITurnoServices turnoServices)
        {
            _turnoServices = turnoServices;
        }

        // GET: api/Turno
        [HttpGet]
        public IEnumerable<Turno> Get()
        {
            return _turnoServices.GetAll();
        }

        // GET: api/Turno/5
        [HttpGet("{id}")]
        public Turno Get(int id)
        {
            return _turnoServices.GetById(id);
        }
    }
}