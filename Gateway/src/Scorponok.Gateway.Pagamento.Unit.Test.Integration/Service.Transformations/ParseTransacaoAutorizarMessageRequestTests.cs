using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Scorponok.Gateway.Pagamento.Domain.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.FormaPagamentos;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes;
using Scorponok.Gateway.Pagamento.Transformations;
using Scorponok.Gateway.Pagamento.Unit.Test.Integration.Commands;
using Scorponok.Shared.Contracts.Messages.Autorizar.Requests;
using System;
using Xunit;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Integration.Service.Transformations
{
    /// <summary>
    /// Agumas Referencias
    ///     https://dotnetthoughts.net/using-automapper-in-aspnet-core-project/
    ///     https://dotnetcoretutorials.com/2017/09/23/using-automapper-asp-net-core/
    /// </summary>
    public class ParseTransacaoAutorizarMessageRequestTests : BaseIntegrationTest
    {
        private IMapper _mapper;

        public ParseTransacaoAutorizarMessageRequestTests()
        {
            var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<TransacaoAutorizarMessageRequestProfile>();
                    cfg.AddProfile<PedidoAutorizarMessageRequestProfile>();
                });

            _mapper = config.CreateMapper();
            _services.AddSingleton(_mapper);
        }

        [Fact]
        public void Parse_entidade_transacao_para_autoriza_message_request()
        {
            ////Arrange
            //var pedido = Pedido.Factory.Create(new Loja(), "", 1, "32423423424", "scorponok");
            
            //pedido.AdicionaFormaPagamentoCartao(1, Guid.NewGuid().ToString(), "Scorponok");

            //var transacao = ((FormaPagamentoCartao)pedido.FormaPagamento).Cartao.Transactions
            
            ////Act
            //var pedidoToAutorizaMessageRequest = _mapper.Map<Transacao, TransactionAutorizarMessageRequest>(pedido);

            ////Assert's
            //pedidoToAutorizaMessageRequest.Should().NotBeNull();
            ////pedidoToAutorizaMessageRequest.IdentificadorPedido.Should().Be(pedido.IdentificadorPedido);
        }
    }
}
