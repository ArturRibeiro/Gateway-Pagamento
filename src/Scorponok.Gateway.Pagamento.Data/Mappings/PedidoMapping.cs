using Microsoft.EntityFrameworkCore;
using Scorponok.Gateway.Pagamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Scorponok.Gateway.Pagamento.Data.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> mp)
        {
            mp.ToTable("Pedido");

            mp.HasKey(x => x.Id);

            mp.Property(x => x.DataCriacao)
                .HasColumnName("DataCriacao")
                .IsRequired();

            mp.HasOne(x => x.Loja)
                .WithMany(x => x.Pedidos)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            mp.Property(x => x.IdentificadorPedido)
                .HasMaxLength(60)
                .IsRequired();

            //mp.HasOne(x => x.FormaPagamentoBoleto)
            //    .WithOne(x => x.Pedido);

            //mp.HasOne(x => x.FormaPagamentoCartaoCredito)
            //    .WithOne(x => x.Pedido);
        }
    }
}
