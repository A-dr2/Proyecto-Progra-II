using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IReservaServices
    {
        public List<Reserva> GetReservas();
        public Reserva GetReservaById(int id);
        public Reserva CreateReserva(Reserva reserva);
        public Reserva UpdateReserva(int id, Reserva reserva);
        public void DeleteReserva(int id);
    }
}
