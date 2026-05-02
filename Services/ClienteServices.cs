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

        public Cliente CreateUsuario(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }

        public void DeleteUsuario(int id)
        {
            var cliente = _context.Clientes.Find(id);

            if (cliente is null)
                throw new KeyNotFoundException($"No existe un cliente con Id {id}.");

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

        public Cliente GetUsuarioById(int id)
        {
            var cliente = _context.Clientes.Find(id);

            if (cliente is null)
                throw new KeyNotFoundException($"No existe un cliente con Id {id}.");

            return cliente;
        }

        public List<Cliente> GetUsuarios()
        {
            return _context.Clientes.ToList();
        }

        public Cliente UpdateUsuario(int id, Cliente usuario)
        {
            var existente = _context.Clientes.Find(id);

            if (existente is null)
                throw new KeyNotFoundException($"No existe un cliente con Id {id}.");

            existente.Nombre = usuario.Nombre;
            existente.Telefono = usuario.Telefono;
            existente.Email = usuario.Email;

            _context.SaveChanges();
            return existente;
        }
    }
}
