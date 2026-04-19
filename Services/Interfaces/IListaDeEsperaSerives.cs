using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IListaDeEsperaSerives
    {
        public List<ListaDeEspera> GetListaDeEspera();
       public ListaDeEspera GetListaDeEsperaById(int id);  
       public ListaDeEspera CreateListaDeEspera(ListaDeEspera listaDeEspera);
       public ListaDeEspera UpdateListaDeEspera(int id, ListaDeEspera listaDeEspera);
       public void DeleteListaDeEspera(int id);
    }
}
