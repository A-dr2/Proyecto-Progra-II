using Microsoft.AspNetCore.Mvc;
using Proyecto_Progra_II.Entities;
using Proyecto_Progra_II.Services.Interfaces;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: api/<ClienteController>
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            var result = _clienteServices.GetUsuarios();
            return result;
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            var result = _clienteServices.GetUsuarioById(id);
            return result;
        }

        // POST api/<ClienteController>
        [HttpPost]
        public Cliente Post([FromBody] Cliente NewCliente)
        {

            var result = _clienteServices.CreateUsuario(NewCliente);
            return result;
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public Cliente Put(int id, [FromBody] Cliente NewCliente)
        {
            var result = _clienteServices.UpdateUsuario(id, NewCliente);
            return result;
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _clienteServices.DeleteUsuario(id);
        }
    }
}
