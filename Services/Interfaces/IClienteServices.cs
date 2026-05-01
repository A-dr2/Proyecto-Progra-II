using Proyecto_Progra_II.Dtos;
using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IClienteServices
    {
            public List<Cliente> GetUsuarios();
            public Cliente GetUsuarioById(int id);
            public Cliente CreateUsuario(Cliente cliente);
            public Cliente UpdateUsuario(int id, Cliente usuario);
            public void DeleteUsuario(int id);
    }
}
