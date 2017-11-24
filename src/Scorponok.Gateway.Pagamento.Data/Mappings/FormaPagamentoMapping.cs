using Microsoft.EntityFrameworkCore;
using Scorponok.Gateway.Pagamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Scorponok.Gateway.Pagamento.Data.Mappings
{
    public class FormaPagamentoMapping : IEntityTypeConfiguration<FormaPagamento>
    {
        public void Configure(EntityTypeBuilder<FormaPagamento> mp)
        {
            mp.ToTable("FormaPagamento");

            mp.HasKey(x => x.Id);

            mp.HasOne(x => x.Pedido)
                .WithOne(x => x.FormaPagamento)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            mp.HasDiscriminator<string>("TipoPagamento")
                .HasValue<FormaPagamentoBoleto>("boleto")
                .HasValue<FormaPagamentoCartaoCredito>("cartao");
        }
    }
}
