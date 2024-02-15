using Ploomes.API.Domain.DTOs;
using Ploomes.API.Domain.Models;

namespace Ploomes.API.Infra
{
    public interface IClienteRepository
    {
        Task<Cliente> CreateCliente(ClienteDTO cliente);
        Cliente GetCliente(Cliente cliente);
        IEnumerable<Cliente> GetClientes();
        Task<Cliente> UpdateCliente(Cliente cliente);
    }
}