using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IListaEsperaServices
    {
        public List<ListaDeEspera> ObtenerListaDeEspera();
        public List<ListaDeEspera> ObtenerlistaPorId(int id);

    }
}
