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

            mp.HasKey(x => x.Id).HasName("Id");
            mp.HasKey(x => x.DataCriacao).HasName("DataCriacao");

            mp.Property(x => x.IdentificadorPedido);
        }
    }
}
