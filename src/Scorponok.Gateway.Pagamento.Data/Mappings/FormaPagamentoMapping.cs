using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scorponok.Gateway.Pagamento.Domain.Models.FormaPagamentos;

namespace Scorponok.Gateway.Pagamento.Cross.Cutting.Data.Mappings
{
    public class FormaPagamentoMapping : IEntityTypeConfiguration<FormaPagamento>
    {
        public void Configure(EntityTypeBuilder<FormaPagamento> mb)
        {
            mb.ToTable("FORMA_PAGAMENTO");

            mb.HasKey(x => x.Id);

            mb.HasDiscriminator<string>("type")
                .HasValue<Boleto>("boleto")
                .HasValue<FormaPagamentoCartao>("cartao");

            mb.HasOne(x => x.Pedido)
                .WithOne(x => x.FormaPagamento)
                .IsRequired();
        }
    }
}
