using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Scorponok.Gateway.Pagamento.Domain.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas;
using Scorponok.Gateway.Pagamento.Transformations;
using Scorponok.Gateway.Pagamento.Unit.Test.Integration.Commands;
using Scorponok.Shared.Contracts.Messages.Autorizar.Requests;
using Xunit;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Integration.Service.Transformations
{
    /// <summary>
    /// Agumas Referencias
    ///     https://dotnetthoughts.net/using-automapper-in-aspnet-core-project/
    ///     https://dotnetcoretutorials.com/2017/09/23/using-automapper-asp-net-core/
    /// </summary>
    public class PedidoToAutorizaMessageRequestTests : BaseIntegrationTest
    {
        private IMapper _mapper;

        public PedidoToAutorizaMessageRequestTests()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile<PedidoToAutorizaMessageRequest>();
                });

            _mapper = config.CreateMapper();
            _services.AddSingleton(_mapper);
        }

        [Fact]
        public void Parse_entidade_pedido_para_autoriza_message_request()
        {
            //Arrange
            var pedido = Pedido.Factory.Create(new Loja(), "A01225WERF", 1, "0123456789", "Scorponok");

            //Act
            var pedidoToAutorizaMessageRequest = _mapper.Map<Pedido, AutorizaMessageRequest>(pedido);

            //Assert's
            pedidoToAutorizaMessageRequest.Should().NotBeNull();
            pedidoToAutorizaMessageRequest.IdentificadorPedido.Should().Be(pedido.IdentificadorPedido);
        }
    }
}
