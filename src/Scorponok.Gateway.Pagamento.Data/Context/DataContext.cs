using Microsoft.EntityFrameworkCore;
using Scorponok.Gateway.Pagamento.Data.Mappings;
using Scorponok.Gateway.Pagamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas;

namespace Scorponok.Gateway.Pagamento.Data.Context
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

            modelBuilder.Ignore<CartaoCredito>();
            modelBuilder.Ignore<Transaction>();
        }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Loja> Lojas { get; set; }

        public DbSet<FormaPagamento> FormaPagamentos { get; set; }
    }
}
