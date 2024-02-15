namespace Ploomes.API.Domain.Models
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid ContaId { get; set; }
    }
}
