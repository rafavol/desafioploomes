using Ploomes.API.Domain.Models;
using System.Text.Json.Serialization;

namespace Ploomes.API.Domain.DTOs
{
    public class ContaDTO
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<ClienteDTO> Clientes { get; set; }

    }
}
