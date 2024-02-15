using Ploomes.API.Domain.DTOs;
using Ploomes.API.Domain.Models;

namespace Ploomes.API.Infra
{
    public interface IContaRepository
    {
        Task<Conta> CreateConta(ContaDTO conta);
        Conta GetConta(Conta conta);
        IEnumerable<Conta> GetContas();
    }
}