using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface ListaDeEsperaServices
    {
        public List<ListaDeEspera> GetAllListaDeEspera();
        public ListaDeEspera GetListaDeEsperaById(int id);
        public ListaDeEspera ActualizarLista(int id, ListaDeEspera listaDeEspera);
        
    }
}
