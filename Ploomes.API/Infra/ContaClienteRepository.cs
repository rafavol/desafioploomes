using Ploomes.API.DBContext;
using Ploomes.API.Domain.DTOs;
using Ploomes.API.Domain.Models;

namespace Ploomes.API.Infra
{
    public class ContaClienteRepository : IContaClienteRepository
    {
        private readonly IContaRepository _contaRepository;
        private readonly IClienteRepository _clienteRepository;

        public ContaClienteRepository(IContaRepository contaRepository, IClienteRepository clienteRepository)
        {
            _contaRepository = contaRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<ContaDTO> GetContaDetalhe(Conta conta)
        {
            var contaDB = _contaRepository.GetConta(conta);
            var clientes = _clienteRepository.GetClientes().Where(e => e.ContaId.ToString().Equals(contaDB.Id.ToString()));
            var contaDTO = new ContaDTO
            {
                DataCriacao = contaDB.DataCriacao,
                Id = contaDB.Id,
                Clientes = clientes.Select(e => new ClienteDTO { Name = e.Name, Email = e.Email }).ToList(),
            };
            return contaDTO;
        }
    }
}
