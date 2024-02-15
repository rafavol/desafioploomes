using Microsoft.EntityFrameworkCore;
using Ploomes.API.DBContext;
using Ploomes.API.Domain.DTOs;
using Ploomes.API.Domain.Models;

namespace Ploomes.API.Infra
{
    public class ClienteRepository : IClienteRepository
    {
        protected readonly ApplicationContext _context;
        public ClienteRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return _context.Clientes.AsNoTracking();
        }

        public Cliente GetCliente(Cliente cliente)
        {
            if (cliente is null)
            {
                throw new ArgumentNullException(nameof(cliente));
            }
            Cliente clienteDB = GetClientes().First(e => e.Id.Equals(cliente.Id));
            if (clienteDB is not null)
            {
                return clienteDB;
            }
            return null;
        }

        public async Task<Cliente> CreateCliente(ClienteDTO cliente)
        {
            try
            {
                var clienteModel = new Cliente
                {
                    Id = Guid.NewGuid(),
                    Email = cliente.Email,
                    Name = cliente.Name,
                    ContaId = cliente.ContaId,
                };
                _context.Clientes.Add(clienteModel);
                await _context.SaveChangesAsync();
                return clienteModel;
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}\nStackTrace:{e.StackTrace}");
            }
        }

        public async Task<Cliente> UpdateCliente(Cliente cliente)
        {
            try
            {
                var clienteDB = GetCliente(cliente);
                clienteDB.Name = cliente.Name;
                clienteDB.Email = cliente.Email;
                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}\nStackTrace:{e.StackTrace}");
            }
        }
    }
}
