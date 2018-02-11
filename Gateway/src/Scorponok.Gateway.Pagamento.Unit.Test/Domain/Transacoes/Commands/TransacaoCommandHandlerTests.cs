using FizzWare.NBuilder;
using Moq;
using Scorponok.Gateway.Pagamento.Domain.Core.Bus;
using Scorponok.Gateway.Pagamento.Domain.Core.Notifications;
using Scorponok.Gateway.Pagamento.Domain.Interfaces;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes.CommandHandlers;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes.CommandHandlers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Domain.Transacoes.Commands
{
    public class TransacaoCommandHandlerTests
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IBus> _mockBus;
        private Mock<IDomainNotificationHandler<DomainNotification>> _mockNotification;

        public TransacaoCommandHandlerTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockBus = new Mock<IBus>();
            _mockNotification = new Mock<IDomainNotificationHandler<DomainNotification>>();
        }

        //[Fact]
        //public void Autorizar_transacao_com_sucesso()
        //{
        //    var transacao = Builder<Transacao>
        //        .CreateNew()
        //        .Build();

        //    //Arrange's
        //    var autorizarTransacaoEventComman = new AutorizarTransacaoEventCommand(transacao);

        //    //Act's
        //    var command = new TransacaoCommandHandler(_mockUnitOfWork.Object, _mockBus.Object, _mockNotification.Object);
        //    command.Handle(autorizarTransacaoEventComman);


        //    //Assert's
        //    _mockUnitOfWork.Verify(x => x.Commit(), Times.Once);
        //    //_mockUnitOfWork.Verify(x => x.Commit(), Times.Once);

        //}
    }
}
