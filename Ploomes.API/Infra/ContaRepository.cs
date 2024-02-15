using Microsoft.EntityFrameworkCore;
using Ploomes.API.DBContext;
using Ploomes.API.Domain.DTOs;
using Ploomes.API.Domain.Models;

namespace Ploomes.API.Infra
{
    public class ContaRepository : IContaRepository
    {
        protected readonly ApplicationContext _context;
        public ContaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Conta> GetContas()
        {
            return _context.Contas.AsNoTracking();
        }

        public Conta GetConta(Conta conta)
        {
            if (conta is null)
            {
                throw new ArgumentNullException(nameof(conta));
            }
            Conta contaDB = GetContas().First(e => e.Id.Equals(conta.Id));
            if (contaDB is not null)
            {
                return contaDB;
            }
            return null;
        }

        public async Task<Conta> CreateConta(ContaDTO conta)
        {
            try
            {
                var contaModel = new Conta
                {
                    Id = Guid.NewGuid(),
                    DataCriacao = DateTime.UtcNow,
                   
                };
                _context.Contas.Add(contaModel);
                await _context.SaveChangesAsync();
                return contaModel;
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}\nStackTrace:{e.StackTrace}");
            }
        }

    }
}
