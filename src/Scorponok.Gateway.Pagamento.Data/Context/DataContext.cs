using Microsoft.EntityFrameworkCore;
using Scorponok.Gateway.Pagamento.Data.Mappings;
using Scorponok.Gateway.Pagamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

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

            modelBuilder.Ignore<FormaPagamento>();

        }

        public DbSet<Pedido> Pedidos { get; set; }

    }
}
