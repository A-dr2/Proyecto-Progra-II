using Microsoft.AspNetCore.Mvc;
using Proyecto_Progra_II.Entities;
using Proyecto_Progra_II.Services.Interfaces;

namespace Proyecto_Progra_II.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaDeEsperaController : ControllerBase
    {
        private readonly IListaDeEsperaServices _listaServices;

        public ListaDeEsperaController(IListaDeEsperaServices listaServices)
        {
            _listaServices = listaServices;
        }

        // GET: api/ListaDeEspera
        [HttpGet]
        public IEnumerable<ListaDeEspera> Get()
        {
            return _listaServices.GetAll();
        }
    }
}