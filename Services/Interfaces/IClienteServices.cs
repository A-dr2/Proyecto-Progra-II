using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IClienteServices
    {
        public List<ClienteDto> GetAll();
        public List<ClienteReservasDto> GetAllWithReservas();
        public Cliente GetById(int id);
        public Cliente Create(Cliente cliente);
        public Cliente Update(int id, Cliente cliente);
        public void Delete(int id);
    }
}