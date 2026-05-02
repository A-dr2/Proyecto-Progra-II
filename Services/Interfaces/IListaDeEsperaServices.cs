using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IListaDeEsperaServices
    {
        public List<ListaDeEspera> GetAll();
        public ListaDeEspera AgregarALista(Reserva reserva);
        public Reserva? ObtenerSiguiente();
    }
}