using FizzWare.NBuilder;
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
    public class AutorizacaoCommandHandlerTests
    {
        private Mock<ILojaService> _mockILojaService;
        private Mock<IUnitOfWork> _mockIUnitOfWork;
        private Mock<IBus> _mockIBus;
        private Mock<IDomainNotificationHandler<DomainNotification>> _mockNotification;

        public AutorizacaoCommandHandlerTests()
        {
            
            _mockIUnitOfWork = new Mock<IUnitOfWork>();
            _mockIBus = new Mock<IBus>();
            _mockNotification = new Mock<IDomainNotificationHandler<DomainNotification>>();
            _mockILojaService = new Mock<ILojaService>();
        }

        [Theory, InlineData("A14587522477", 1233, "", "Artur Araújo Santos Ribeiro")]
        public void Realiza_uma_autorizacao_com_forma_pagamento_carao_credito(string identificadorPedido, int valorEmCentavos, string numeroCartaoCredito, string portador)
        {
            #region Arrange

            var theEvent = new AutorizarPedidoEventCommand(Guid.NewGuid(), identificadorPedido, valorEmCentavos, numeroCartaoCredito, portador);

            var loja = Builder<Loja>
                .CreateNew()
                .Build();

            #endregion

            #region Stub's

            _mockILojaService.Setup(x => x.Save(theEvent.LojaToken, theEvent.IdentificadorPedido, theEvent.ValorCentavos, theEvent.NumeroCartaoCredito, theEvent.Portador))
                .Returns(loja);
            
            _mockIUnitOfWork.Setup(x => x.Commit()).Returns(new CommandResult(true));

            #endregion

            #region Act

            var command = new PedidoCommandHandler(_mockIUnitOfWork.Object, _mockIBus.Object, _mockILojaService.Object, _mockNotification.Object);
            command.Handle(theEvent);

            #endregion

            #region Assert's 

            _mockILojaService.Verify(x => x.Save(theEvent.LojaToken, theEvent.IdentificadorPedido, theEvent.ValorCentavos, theEvent.NumeroCartaoCredito, theEvent.Portador), Times.Once);
            _mockIUnitOfWork.Verify(x => x.Commit(), Times.Once);
            #endregion

        }
    }
}
