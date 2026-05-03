using Microsoft.AspNetCore.Mvc;
using Proyecto_Progra_II.Entities;
using Proyecto_Progra_II.Services.Interfaces;

namespace Proyecto_Progra_II.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaServices _reservaServices;

        public ReservaController(IReservaServices reservaServices)
        {
            _reservaServices = reservaServices;
        }

        // GET: api/Reserva
        [HttpGet]
        public IEnumerable<ReservaDto> Get()
        {
            return _reservaServices.GetAll();
        }

        // GET: api/Reserva/5
        [HttpGet("{id}")]
        public Reserva Get(int id)
        {
            return _reservaServices.GetById(id);
        }

        // POST: api/Reserva
        [HttpPost]
        public ActionResult Post([FromBody] ReservaDto reservaDto)
        {
            try
            {
                var reserva = new Reserva
                {
                    Fecha = reservaDto.Fecha,
                    CantidadPersonas = reservaDto.CantidadPersonas,
                    ClienteId = reservaDto.ClienteId,
                    EstadoReserva = reservaDto.EstadoReserva
                };

                var resultado = _reservaServices.Create(reserva);
                if (resultado == null)
                    return Ok("No hay mesas disponibles, agregado a lista de espera");
                return Ok(resultado);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Reserva/5/estado
        [HttpPut("{id}/estado")]
        public Reserva CambiarEstado(int id, [FromBody] EstadoReserva estado)
        {
            return _reservaServices.CambiarEstado(id, estado);
        }

        // POST: api/Reserva/liberarCupo
        [HttpPost("liberarCupo")]
        public IActionResult LiberarCupo()
        {
            _reservaServices.LiberarCupo();
            return Ok("Cupo liberado y asignado al siguiente en lista de espera");
        }

        // DELETE: api/Reserva/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _reservaServices.Delete(id);
        }
    }
}