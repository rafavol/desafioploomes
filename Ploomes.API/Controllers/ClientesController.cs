using Microsoft.AspNetCore.Mvc;
using Ploomes.API.Domain.DTOs;
using Ploomes.API.Domain.Models;
using Ploomes.API.Infra;

namespace Ploomes.API.Controllers
{
    public class ClientesController : Controller
    {

        private readonly IClienteRepository _clienteRepository;
        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        // PUT: Cliente/UpdateCliente
        [HttpPut]
        public async Task<ActionResult<Cliente>> UpdateCliente(Cliente cliente)
        {
            try
            {
                var clienteAtualizada = await _clienteRepository.UpdateCliente(cliente);
                return Ok(clienteAtualizada);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(new { errors = e.Message, cliente });
            }
        }

        // POST: Cliente/CreateCliente
        [HttpPost]
        public async Task<ActionResult<Cliente>> CreateCliente(ClienteDTO cliente)
        {
            try
            {
                var clienteNova = await _clienteRepository.CreateCliente(cliente);
                return Created("CreateCliente", clienteNova);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(new { errors = e.Message, cliente });
            }
        }
    }
}
