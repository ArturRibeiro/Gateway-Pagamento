using FizzWare.NBuilder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scorponok.Gateway.Pagamento.Data.Context;
using Scorponok.Gateway.Pagamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Bogus;
using Bogus.Extensions.Brazil;
using Microsoft.Extensions.Configuration;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas;
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

            //builder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Gateway.Pagamentos.Dev;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
            //    .UseInternalServiceProvider(serviceProvider);

            builder.UseSqlServer($"Data Source=DESKTOP-T5U2T7J;Initial Catalog=Gateway.Pagamento.Dev;Integrated Security=True")
                .UseInternalServiceProvider(serviceProvider);

            _context = new DataContext(builder.Options);

            // Start with a clean database

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            //_context.Database.Migrate();
        }

        [Fact]
        public void Start()
        {
            try
            {
                var loja = Builder<Loja>
            .CreateNew()
                .With(x => x.Nome, Faker.Company.Name())
                .With(x => x.Cnpj, Faker.Company.Suffix())
                .With(x => x.RazaoSocial, Faker.Company.Name())
            .Build();
                _context.Lojas.Add(loja);


                var pedido = Builder<Pedido>
                    .CreateNew()
                        .With(x => x.IdentificadorPedido, "A0012121331")
                        .With(x => x.Loja, loja)
                    .Build();
                _context.Pedidos.Add(pedido);

                var formaPagamentoCartao = Builder<FormaPagamentoCartaoCredito>
                    .CreateNew()
                        .With(x => x.Pedido, pedido)
                    .Build();
                _context.FormaPagamentos.Add(formaPagamentoCartao);

                //var formaPagamentoBoleto = Builder<FormaPagamentoBoleto>
                //    .CreateNew()
                //        .With(x => x.Pedido, pedido)
                //    .Build();
                //_context.FormaPagamentos.Add(formaPagamentoBoleto);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
            }


        }
    }
}
