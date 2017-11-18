using Moq;
using Scorponok.Gateway.Pagamento.Domain.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.CommandHandlers;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.Commands;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.Respository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Commands
{
    public class PedidoCommandHandlerTests
    {
        private Mock<IPedidoRepository> _mockIPedidoRepository;

        public PedidoCommandHandlerTests()
        {
            _mockIPedidoRepository = new Mock<IPedidoRepository>();
        }

        [Theory, InlineData("A14587522477", 1233, "", "Artur Araújo Santos Ribeiro")]
        public void Realiza_uma_autorizacao(string identificadorPedido, int valorEmCentavos, string numeroCartaoCredito, string portador)
        {
            #region Arrange

            var theEvent = new AutorizarEventCommand(identificadorPedido, valorEmCentavos, numeroCartaoCredito, portador);

            #endregion

            #region Stub's

            _mockIPedidoRepository.Setup(x => x.Add(It.IsAny<Pedido>())).Verifiable();

            #endregion

            #region Act

            var command = new PedidoCommandHandler(_mockIPedidoRepository.Object);
            command.Handle(theEvent);

            #endregion

            #region Assert's 

            _mockIPedidoRepository.Verify(x => x.Add(It.IsAny<Pedido>()), Times.Once);

            #endregion

        }
    }
}
