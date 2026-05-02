using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IUsuariosServices
    {
            public List<Usuarios> GetUsuarios();
            public Usuarios GetUsuarioById(int id);
            public Usuarios CreateUsuario(Usuarios usuario);
            public Usuarios UpdateUsuario(int id, Usuarios usuario);
            public void DeleteUsuario(int id);
    }
}
