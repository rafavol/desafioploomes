using Ploomes.API.Domain.DTOs;
using Ploomes.API.Domain.Models;

namespace Ploomes.API.Infra
{
    public interface IContaClienteRepository
    {
        Task<ContaDTO> GetContaDetalhe(Conta conta);
    }
}