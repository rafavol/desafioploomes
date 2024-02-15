using System.Text.Json.Serialization;

namespace Ploomes.API.Domain.DTOs
{
    public class ClienteDTO
    {
        [JsonPropertyName("nome")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("conta_id")]
        public Guid ContaId { get; set; }
    }
}
