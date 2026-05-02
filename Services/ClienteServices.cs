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
            _context.Database.EnsureCreated();
        }

        public List<ClienteDto> GetAll()
        {
            return _context.Clientes
                .Select(c => new ClienteDto
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Telefono = c.Telefono,
                    Email = c.Email
                }).ToList();
        }

        public List<ClienteReservasDto> GetAllWithReservas()
        {
            return _context.Clientes
                .Select(c => new ClienteReservasDto
                {
                    Nombre = c.Nombre,
                    Reservas = c.Reservas
                        .OrderBy(r => r.Fecha)
                        .Select(r => new ReservaDto
                        {
                            Id = r.Id,
                            Fecha = r.Fecha,
                            CantidadPersonas = r.CantidadPersonas,
                            ClienteId = r.ClienteId,
                            EstadoReserva = r.EstadoReserva
                        }).ToList()
                }).ToList();
        }

        public Cliente GetById(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.Id == id)
                ?? throw new KeyNotFoundException("Cliente no encontrado");
        }

        public Cliente Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }

        public Cliente Update(int id, Cliente cliente)
        {
            var existente = GetById(id);
            existente.Nombre = cliente.Nombre;
            existente.Telefono = cliente.Telefono;
            existente.Email = cliente.Email;
            _context.SaveChanges();
            return existente;
        }

        public void Delete(int id)
        {
            var cliente = GetById(id);
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }
    }
}