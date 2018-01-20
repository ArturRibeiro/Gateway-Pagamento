using Microsoft.EntityFrameworkCore;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Scorponok.Gateway.Pagamento.Cross.Cutting.Data.Mappings
{
    public class PedidoHistoricoMapping : IEntityTypeConfiguration<TransacaoHistorico>
    {
        public void Configure(EntityTypeBuilder<TransacaoHistorico> mp)
        {
            mp.ToTable("Historico_Transacao");

            mp.HasKey(x => x.Id);

            mp.OwnsOne(o => o.LojaVO, c =>
            {
                c.Property(p => p.LojaId).HasColumnName("LojaId");
                c.Property(p => p.LojaNome).HasColumnName("LojaNome");
            });

            mp.OwnsOne(o => o.PedidoVO, c =>
            {
                c.Ignore(p => p.PedidoId);
                //c.Property(p => p.PedidoId).HasColumnName("PedidoId");
                c.Property(p => p.PedidoIdentificador).HasColumnName("PedidoIdentificador");
                c.Property(p => p.PedidoDataCriacao).HasColumnName("PedidoDataCriacao");
            });

            mp.OwnsOne(o => o.TransacaoVO, c =>
            {
                c.Property(p => p.TransacaoStatus).HasColumnName("TransacaoStatus");
                c.Property(p => p.TransacaoNumeroParcelas).HasColumnName("TransacaoNumeroParcelas");
            });

            mp.OwnsOne(o => o.FormaPagamentoVO, c =>
            {
                c.Property(p => p.FormaPagamentoTipo).HasColumnName("FormaPagamentoTipo");
                c.Property(p => p.FormaPagamentoValorCentavos).HasColumnName("FormaPagamentoValorCentavos");
            });

            mp.OwnsOne(o => o.CartaoVO, c =>
            {
                c.Ignore(x => x.CartaoCvv);
                c.Property(p => p.CartaoBandeira).HasColumnName("CartaoBandeira");
                c.Property(p => p.CartaoExpiracao).HasColumnName("CartaoExpiracao");
                c.Property(p => p.CartaoNumero).HasColumnName("CartaoNumero");
                c.Property(p => p.CartaoPortador).HasColumnName("CartaoPortador");

            });



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
