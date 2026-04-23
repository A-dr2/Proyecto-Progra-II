using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IUsuariosServices
    {
            public List<Usuario> GetUsuarios();
            public Usuario GetUsuarioById(int id);
            public Usuario CreateUsuario(Usuario usuario);
            public Usuario UpdateUsuario(int id, Usuario usuario);
            public void DeleteUsuario(int id);
    }
}
