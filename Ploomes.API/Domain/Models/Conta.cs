namespace Ploomes.API.Domain.Models
{
    public class Conta
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; } 
        public List<Cliente> Clientes { get; set; }
    }
}
