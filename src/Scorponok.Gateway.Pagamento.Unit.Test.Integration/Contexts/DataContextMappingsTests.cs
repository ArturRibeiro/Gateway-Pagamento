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
using Scorponok.Gateway.Pagamento.Domain.Models.FormaPagamentos;
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

            builder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=Gateway.Pagamento.Dev;Integrated Security=True")
                .UseInternalServiceProvider(serviceProvider);

            _context = new DataContext(builder.Options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [Fact]
        public void Start()
        {
            var loja = Builder<Loja>
                .CreateNew()
                    .With(x => x.Nome, Faker.Company.Name())
                    .With(x => x.Cnpj, Faker.Company.Suffix())
                    .With(x => x.RazaoSocial, Faker.Company.Name())
                .Build();
            _context.Lojas.Add(loja);

            #region Pedido com forma de pagamento boleto
            var pedido1 = Builder<Pedido>
                .CreateNew()
                    .With(x => x.IdentificadorPedido, "A0012121331")
                    .With(x => x.Loja, loja)
                .Build();
            _context.Pedidos.Add(pedido1);

            var formaPagamentoBoleto = Builder<FormaPagamentoBoleto>
                .CreateNew()
                    .With(x => x.Id, Guid.NewGuid())
                    .With(x => x.Pedido, pedido1)
                .Build();
            _context.FormaPagamentoBoletos.Add(formaPagamentoBoleto);
            #endregion

            //#region Pedido com forma de pagamento cartão de credito
            //var pedido2 = Builder<Pedido>
            //.CreateNew()
            //    .With(x => x.IdentificadorPedido, "A0012121332")
            //    .With(x => x.Loja, loja)
            //.Build();
            //_context.Pedidos.Add(pedido2);

            //var formaPagamentoCartao = Builder<FormaPagamentoCartaoCredito>
            //    .CreateNew()
            //    .With(x => x.Id, Guid.NewGuid())
            //        .With(x => x.Pedido, pedido2)
            //    .Build();
            //_context.FormaPagamentoCartaoCreditos.Add(formaPagamentoCartao); 
            //#endregion

            _context.SaveChanges();
        }
    }
}
