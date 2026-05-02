using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IReservaServices
    {
        public List<Reserva> GetAll();
        public Reserva GetById(int id);
        public Reserva? Create(Reserva reserva);
        public Reserva CambiarEstado(int id, EstadoReserva estado);
        public void LiberarCupo();
        public void Delete(int id);
    }
}