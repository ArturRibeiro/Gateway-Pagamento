using FizzWare.NBuilder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scorponok.Gateway.Pagamento.Domain.Models;
using System;
using Scorponok.Gateway.Pagamento.Cross.Cutting.Data.Context;
using Scorponok.Gateway.Pagamento.Domain.Models.FormaPagamentos;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes;

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

            builder.UseSqlServer(@"Data Source=DESKTOP-T5U2T7J;Initial Catalog=Gateway.Pagamento.Dev;Integrated Security=True")
                .UseInternalServiceProvider(serviceProvider);

            _context = new DataContext(builder.Options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        //[Fact]
        public void Start()
        {
            var loja = Builder<Loja>
                .CreateNew()
                    .With(x => x.Id, Guid.NewGuid())
                    .With(x => x.Nome, Faker.Company.Name())
                    .With(x => x.Cnpj, Faker.Company.Suffix())
                    .With(x => x.RazaoSocial, Faker.Company.Name())
                .Build();
            _context.Lojas.Add(loja);

            #region Pedido com forma de pagamento boleto
            var pedido1 = Builder<Pedido>
                .CreateNew()
                    .With(x => x.Id, Guid.NewGuid())
                    .With(x => x.IdentificadorPedido, "A0012121331")
                    .With(x => x.Loja, loja)
                .Build();
            _context.Pedidos.Add(pedido1);

            var boleto = Builder<Boleto>
                .CreateNew()
                    .With(x => x.Id, Guid.NewGuid())
                    .With(x => x.Pedido, pedido1)
                .Build();
            _context.Boletos.Add(boleto);
            #endregion

            #region Pedido com forma de pagamento cartão de credito
            var pedido2 = Builder<Pedido>
            .CreateNew()
                .With(x => x.IdentificadorPedido, "A0012121332")
                .With(x => x.Loja, loja)
            .Build();
            _context.Pedidos.Add(pedido2);

            var cartao = Builder<Cartao>
                .CreateNew()
                    .With(x => x.Id, Guid.NewGuid())
                    .With(x => x.Bandeira, "Discover Network")
                    .With(x => x.Numero, "4024007144419032")
                    .With(x => x.Cvv, "213")
                    .With(x => x.Expiracao, 012021)
                    .With(x => x.Portador, Faker.Name.FullName())
                .Build();
            _context.Cartoes.Add(cartao);

            var formaPagamentoCartao = Builder<FormaPagamentoCartao>
            .CreateNew()
                .With(x => x.Id, Guid.NewGuid())
                .With(x => x.ValorCentavos, 500)
                .With(x => x.Pedido, pedido2)
                .With(x => x.Cartao, cartao)
            .Build();
            _context.CreditcardPayments.Add(formaPagamentoCartao);
            #endregion

            var transacao = Builder<Transacao>
                .CreateNew()
                    .With(x => x.Id, Guid.NewGuid())
                    .With(x => x.Cartao, cartao)
                .Build();
            _context.Transacoes.Add(transacao);

            _context.SaveChanges();
        }
    }
}
