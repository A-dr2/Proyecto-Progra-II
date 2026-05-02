using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IReservaServices
    {
        public List<Reservas> GetReservas();
        public Reservas GetReservaById(int id);
        public Reservas CreateReserva(Reservas reserva);
        public Reservas UpdateReserva(int id, Reservas reserva);
        public void DeleteReserva(int id);
    }
}
