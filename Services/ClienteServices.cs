
using Proyecto_Progra_II.Entities;
using Proyecto_Progra_II.MiDbContext;
using Proyecto_Progra_II.Services.Interfaces;

namespace Proyecto_Progra_II.Services
{
    public class ClienteServices : IClienteServices
    {
       private readonly MyAppDbContext _context;
        public ClienteServices(MyAppDbContext context)
        {
            _context = context;
        }
        public Cliente CreateUsuario (Cliente cliente)
        {
           _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return cliente;

        }



 


        public void DeleteUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente GetUsuarioById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> GetUsuarios()
        {
            return _context.Clientes.ToList();
        }

        public Cliente UpdateUsuario(int id, Cliente usuario)
        {
            throw new NotImplementedException();
        }
    }
}
