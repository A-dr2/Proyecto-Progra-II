using Microsoft.AspNetCore.Mvc;
using Proyecto_Progra_II.Entities;
using Proyecto_Progra_II.Services.Interfaces;

namespace Proyecto_Progra_II.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServices _clienteServices;

        public ClienteController(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        // GET: api/Cliente
        [HttpGet]
        public IEnumerable<ClienteDto> Get()
        {
            return _clienteServices.GetAll();
        }

        // GET: api/Cliente/reservas
        [HttpGet("reservas")]
        public IEnumerable<ClienteReservasDto> GetWithReservas()
        {
            return _clienteServices.GetAllWithReservas();
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            return _clienteServices.GetById(id);
        }

        // POST: api/Cliente
        [HttpPost]
        public Cliente Post([FromBody] Cliente cliente)
        {
            return _clienteServices.Create(cliente);
        }

        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public Cliente Put(int id, [FromBody] Cliente cliente)
        {
            return _clienteServices.Update(id, cliente);
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _clienteServices.Delete(id);
        }
    }
}