using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Scorponok.Gateway.Pagamento.Domain.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos;
using Scorponok.Gateway.Pagamento.Transformations;
using Scorponok.Gateway.Pagamento.Unit.Test.Integration.Commands;
using Scorponok.Shared.Contracts.Messages.Autorizar.Requests;
using Xunit;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Integration.Service.Transformations
{
    public class ParsePedidoAutorizarMessageRequestTests : BaseIntegrationTest
    {
        private IMapper _mapper;

        public ParsePedidoAutorizarMessageRequestTests()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile<PedidoAutorizarMessageRequestProfile>();
                });

            _mapper = config.CreateMapper();
            _services.AddSingleton(_mapper);
        }

        [Fact]
        public void Parse_entidade_pedido_para_autoriza_message_request()
        {
            //Arrange
            var pedido = Pedido.Factory.Create(new Loja(), "", 1, "32423423424", "scorponok");

            //Act
            var pedidoToAutorizaMessageRequest = _mapper.Map<Pedido, OrderMessageRequest>(pedido);

            //Assert's
            pedidoToAutorizaMessageRequest.Should().NotBeNull();
            pedidoToAutorizaMessageRequest.OrderReference.Should().Be(pedido.IdentificadorPedido);
        }
    }
}
