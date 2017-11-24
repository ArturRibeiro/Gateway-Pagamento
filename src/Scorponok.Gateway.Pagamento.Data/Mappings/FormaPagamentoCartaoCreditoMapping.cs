using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scorponok.Gateway.Pagamento.Domain.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.FormaPagamentos;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos;

namespace Scorponok.Gateway.Pagamento.Data.Mappings
{
    public class FormaPagamentoCartaoCreditoMapping : IEntityTypeConfiguration<FormaPagamentoCartaoCredito>
    {
        public void Configure(EntityTypeBuilder<FormaPagamentoCartaoCredito> mp)
        {
            mp.ToTable("FormaPagamentoCartaoCredito");

            mp.HasKey(x => x.Id);

            //mp.HasOne(x => x.Pedido)
            //    .WithOne(x => x.FormaPagamentoCartaoCredito)
            //    .OnDelete(DeleteBehavior.Restrict)
            //    .IsRequired();
        }
    }
}