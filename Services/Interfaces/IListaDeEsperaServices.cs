using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IListaDeEsperaServices
    {
        public ListaDeEspera AgregarALista(Reserva reserva); // crea la lista de espera
        public Reserva? ObtenerSiguiente(); // obtiene la siguiente reserva en la lista de espera
        public List<ListaDeEspera> GetListaDeEspera(); // obtiene la lista de espera completa
    }
}