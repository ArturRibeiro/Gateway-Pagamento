using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scorponok.Gateway.Pagamento.Domain.Models;

namespace Scorponok.Gateway.Pagamento.Cross.Cutting.Data.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> mp)
        {
            mp.ToTable("PEDIDO");

            mp.HasKey(x => x.Id);

            mp.Property(x => x.DataCriacao)
                .HasColumnName("DataCriacao")
                .IsRequired();

            mp.HasOne(x => x.Loja)
                .WithMany(x => x.PedidosInternal)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            mp.Property(x => x.IdentificadorPedido)
                .HasMaxLength(60)
                .IsRequired();

            mp.HasOne(x => x.FormaPagamento)
                .WithOne(x => x.Pedido)
                .IsRequired();
        }
    }
}
