using Proyecto_Progra_II.Entities;
using Proyecto_Progra_II.MiDbContext;
using Proyecto_Progra_II.Services.Interfaces;

 namespace Proyecto_Progra_II.Services
{
    public class ListaDeEsperaServices : IListaDeEsperaServices   // esta parte sigue necesitando de reserva 
    {
        private readonly MyAppDbContext _lista;

        public ListaDeEsperaServices(MyAppDbContext context)
        {
            _lista = context;
        }


        public ListaDeEspera AgregarALista(Reserva reserva)
        {
            var listaDeEspera = new ListaDeEspera
            {
                FechaSolicitud = DateTime.Now,
                Reserva = reserva
            };
            _lista.ListasDeEspera.Add(listaDeEspera);
            _lista.SaveChanges();
            return listaDeEspera;
        }

        public Reserva? ObtenerSiguiente()
        {
            var siguiente = _lista.ListasDeEspera
                .OrderBy(x => x.FechaSolicitud)
                .FirstOrDefault();
            if (siguiente != null)
            {
                _lista.ListasDeEspera.Remove(siguiente);
                _lista.SaveChanges();
                return siguiente.Reserva;
            }
            return null;

        }

        public List<ListaDeEspera> GetListaDeEspera()
        {
            return _lista.ListasDeEspera.OrderBy(x => x.FechaSolicitud).ToList();
        }

        
    } 
} 