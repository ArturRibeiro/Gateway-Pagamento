using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas;

namespace Scorponok.Gateway.Pagamento.Cross.Cutting.Data.Mappings
{
    public class LojaMapping : IEntityTypeConfiguration<Loja>
    {
        public void Configure(EntityTypeBuilder<Loja> mp)
        {
            mp.ToTable("LOJA");

            mp.HasKey(x => x.Id);

            mp.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            mp.Property(x => x.RazaoSocial)
                .HasColumnName("RazaoSocial")
                .HasMaxLength(255)
                .IsRequired();

            mp.Property(x => x.Cnpj)
                .HasColumnName("Cnpj")
                .HasMaxLength(16)
                .IsRequired();

            mp.Property(x => x.DataCriacao)
                .HasColumnName("DataCriacao")
                .IsRequired();

            mp.Property(x => x.DataAtualizacao)
                .HasColumnName("DataAtualizacao");

            mp.Ignore(x => x.Pedidos);

            mp.HasMany(x => x.PedidosInternal)
                .WithOne(x => x.Loja)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
