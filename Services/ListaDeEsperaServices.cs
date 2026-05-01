using Proyecto_Progra_II.Entities;
using Proyecto_Progra_II.Services.Interfaces;

/* namespace Proyecto_Progra_II.Services
{
    public class ListaDeEsperaServices : IListaDeEsperaServices    esta parte sigue necesitando de reserva 
    {
        private static List<ListaDeEspera> _lista = new List<ListaDeEspera>();
        private static int _id = 1;

        public ListaDeEspera AgregarALista(Reserva reserva)
        {
            var nueva = new ListaDeEspera
            {
                Id = _id++,
                Reserva = reserva,        
                FechaSolicitud = DateTime.Now
            };

            _lista.Add(nueva);
            return nueva;
        }

        public Reserva? ObtenerSiguiente()
        {
            if (_lista.Count == 0)
                return null;

            var primero = _lista.OrderBy(x => x.FechaSolicitud).First();

            _lista.Remove(primero);

            return primero.Reserva;
        }

        public List<ListaDeEspera> GetListaDeEspera()
        {
            return _lista.OrderBy(x => x.FechaSolicitud).ToList();
        }
    } 
} */