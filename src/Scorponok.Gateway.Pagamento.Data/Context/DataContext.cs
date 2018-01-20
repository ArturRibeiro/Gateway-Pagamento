using Microsoft.EntityFrameworkCore;
using Scorponok.Gateway.Pagamento.Cross.Cutting.Data.Mappings;
using Scorponok.Gateway.Pagamento.Domain.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.FormaPagamentos;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes;

namespace Scorponok.Gateway.Pagamento.Cross.Cutting.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opcoes)
            : base(opcoes)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PedidoMapping());
            modelBuilder.ApplyConfiguration(new LojaMapping());
            modelBuilder.ApplyConfiguration(new FormaPagamentoMapping());
            modelBuilder.ApplyConfiguration(new CartaoMapping());
            modelBuilder.ApplyConfiguration(new TransacaoMapping());
            modelBuilder.ApplyConfiguration(new PedidoHistoricoMapping());

            
        }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Loja> Lojas { get; set; }

        public DbSet<Boleto> Boletos { get; set; }

        public DbSet<FormaPagamentoCartao> CreditcardPayments { get; set; }

        public DbSet<Cartao> Cartoes { get; set; }

        public DbSet<Transacao> Transacoes { get; set; }

        public DbSet<TransacaoHistorico> TransacaoHistoricos { get; set; }
    }

}
