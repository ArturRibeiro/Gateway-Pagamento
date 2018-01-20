using Microsoft.EntityFrameworkCore;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Scorponok.Gateway.Pagamento.Cross.Cutting.Data.Mappings
{
    public class PedidoHistoricoMapping : IEntityTypeConfiguration<TransacaoHistorico>
    {
        public void Configure(EntityTypeBuilder<TransacaoHistorico> mp)
        {
            mp.ToTable("Historico_Transacao");

            mp.HasKey(x => x.Id);
            mp.OwnsOne(x => x.LojaVO);
            


            //mp.Property(x => x.PedidoId)
            //    .HasColumnName("PedidoId")
            //    .IsRequired();

            //mp.Property(x => x.PedidoIdentificador)
            //    .HasColumnName("IdentificadorPedido")
            //    .IsRequired();

            //mp.Property(x => x.PedidoDataCriacao)
            //    .HasColumnName("DataCriacaoPedido")
            //    .IsRequired();

            //mp.Property(x => x.FormaPagamentoNome)
            //    .HasColumnName("FormaPagamentoDescricao")
            //    .IsRequired();

            //mp.Property(x => x.FormaPagamentoValorCentavos)
            //    .HasColumnName("ValorCentavos")
            //    .IsRequired();

            ////mp.Property(x => x.Nome)
            ////    .HasColumnName("")
            ////    .IsRequired();

            //mp.Property(x => x.TransacaoNumeroParcelas)
            //    .HasColumnName("NumeroParcelas")
            //    .IsRequired();

            //mp.Property(x => x.TransacaoStatus)
            //    .HasColumnName("StatusTransacao")
            //    .IsRequired();
        }
    }
}
