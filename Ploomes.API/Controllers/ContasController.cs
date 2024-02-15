using Microsoft.AspNetCore.Mvc;
using Ploomes.API.Domain.DTOs;
using Ploomes.API.Domain.Models;
using Ploomes.API.Infra;
using System.Collections.Generic;

namespace Ploomes.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ContasController : Controller
    {
        private readonly IContaRepository _contaRepository;
        private readonly IContaClienteRepository _contaClienteRepository;

        public ContasController(IContaRepository contaRepository, IContaClienteRepository contaClienteRepository)
        {
            _contaRepository = contaRepository;
            _contaClienteRepository = contaClienteRepository;
        }

        // GET: Conta/GetContas
        [HttpGet]
        public ActionResult<IEnumerable<Conta>> GetContas(){
            var contas = _contaRepository.GetContas();
            if(contas is null) {
                return NoContent();
            }
            return Ok(contas);
        }


        // GET: Conta/GetContas
        [HttpGet]
        public ActionResult<IEnumerable<Conta>> GetContasDetalhe(Conta conta)
        {
            var contas = _contaClienteRepository.GetContaDetalhe(conta);
            if (contas is null)
            {
                return NoContent();
            }
            return Ok(contas);
        }

        // POST: Conta/CreateConta
        [HttpPost]
        public async Task<ActionResult<Conta>> CreateConta(ContaDTO conta)
        {
            try
            {
                var contaNova = await _contaRepository.CreateConta(conta);
                return Created("CreateConta", contaNova);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(new { errors = e.Message, conta });
            }
        }

        
    }
}
