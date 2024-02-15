using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ploomes.API.Domain.Models;

namespace Ploomes.API.Infra.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {

            builder.HasKey(k => new { k.Id }).HasName("IdCliente");
            builder.Property(p => p.Id).HasColumnName("Id");

            builder.Property(p => p.ContaId).HasColumnName("ContaId");

            builder.HasOne<Conta>().WithMany().HasForeignKey(f => f.ContaId);
        }
    }
}
