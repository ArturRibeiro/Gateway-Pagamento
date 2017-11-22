using FizzWare.NBuilder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scorponok.Gateway.Pagamento.Data.Context;
using Scorponok.Gateway.Pagamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Integration.Contexts
{
    public class DataContextMappingsTests
    {
        private readonly DataContext _context;

        public DataContextMappingsTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();


            var builder = new DbContextOptionsBuilder<DataContext>();

            builder.UseSqlServer($"Data Source=DESKTOP-T5U2T7J;Initial Catalog=Gateway.Pagamento;Integrated Security=True")
                .UseInternalServiceProvider(serviceProvider);

            _context = new DataContext(builder.Options);

            // Start with a clean database
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [Fact]
        public void Start()
        {
            var pedido = Builder<Pedido>
                .CreateNew()
                    .With(x => x.IdentificadorPedido, "A0012121331")
                .Build();

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
        }
    }
}
