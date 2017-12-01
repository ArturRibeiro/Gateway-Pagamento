using Moq;
using Scorponok.Gateway.Pagamento.Domain.Core.Bus;
using Scorponok.Gateway.Pagamento.Domain.Core.Commands;
using Scorponok.Gateway.Pagamento.Domain.Core.Notifications;
using Scorponok.Gateway.Pagamento.Domain.Interfaces;
using Scorponok.Gateway.Pagamento.Domain.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas.IRespository;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.CommandHandlers;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.CommandHandlers.Commands;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IRespository;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IService;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Commands
{
    public class PedidoCommandHandlerTests
    {
        private Mock<IPedidoRepository> _mockIPedidoRepository;
        private Mock<ILojaRepository> _mockILojaRepository;
        private Mock<IUnitOfWork> _mockIUnitOfWork;
        private Mock<IBus> _mockIBus;
        private Mock<IDomainNotificationHandler<DomainNotification>> _mockNotification;
        private Mock<IPedidoService> _mockPedidoService;

        public PedidoCommandHandlerTests()
        {
            _mockIPedidoRepository = new Mock<IPedidoRepository>();
            _mockILojaRepository = new Mock<ILojaRepository>();
            _mockIUnitOfWork = new Mock<IUnitOfWork>();
            _mockIBus = new Mock<IBus>();
            _mockNotification = new Mock<IDomainNotificationHandler<DomainNotification>>();
            _mockPedidoService = new Mock<IPedidoService>();
        }

        [Theory, InlineData("A14587522477", 1233, "", "Artur Araújo Santos Ribeiro")]
        public void Realiza_uma_autorizacao(string identificadorPedido, int valorEmCentavos, string numeroCartaoCredito, string portador)
        {
            #region Arrange

            var theEvent = new AutorizarPedidoEventCommand(Guid.NewGuid(), identificadorPedido, valorEmCentavos, numeroCartaoCredito, portador);

            #endregion

            #region Stub's
            _mockILojaRepository.Setup(x => x.GetById(theEvent.LojaToken)).Returns(new Loja());
            _mockIPedidoRepository.Setup(x => x.Add(It.IsAny<Pedido>())).Verifiable();
            _mockIUnitOfWork.Setup(x => x.Commit()).Returns(new CommandResult(true));

            #endregion

            #region Act

            var command = new PedidoCommandHandler(_mockILojaRepository.Object, _mockIPedidoRepository.Object, _mockIUnitOfWork.Object, _mockIBus.Object, _mockPedidoService.Object, _mockNotification.Object);
            command.Handle(theEvent);

            #endregion

            #region Assert's 

            _mockIPedidoRepository.Verify(x => x.Add(It.IsAny<Pedido>()), Times.Once);
            _mockILojaRepository.Verify(x => x.GetById(theEvent.LojaToken), Times.Once);
            _mockIUnitOfWork.Verify(x => x.Commit(), Times.Once);
            #endregion

        }
    }
}
