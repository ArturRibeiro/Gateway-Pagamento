using Microsoft.EntityFrameworkCore;
using Scorponok.Gateway.Pagamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scorponok.Gateway.Pagamento.Domain.Models.FormaPagamentos;

namespace Scorponok.Gateway.Pagamento.Data.Mappings
{
    public class FormaPagamentoBoletoMapping : IEntityTypeConfiguration<FormaPagamentoBoleto>
    {
        public void Configure(EntityTypeBuilder<FormaPagamentoBoleto> mp)
        {
            mp.ToTable("FormaPagamentoBoleto");

            mp.HasKey(x => x.Id);

            //mp.HasOne(x => x.Pedido)
            //    //.WithOne(x => x.FormaPagamentoBoleto)
            //    .OnDelete(DeleteBehavior.Restrict)
            //    .IsRequired();
        }
    }
}
