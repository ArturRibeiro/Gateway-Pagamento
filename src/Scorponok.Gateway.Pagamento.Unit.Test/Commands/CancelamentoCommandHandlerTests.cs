using FizzWare.NBuilder;
using Moq;
using Scorponok.Gateway.Pagamento.Domain.Core.Bus;
using Scorponok.Gateway.Pagamento.Domain.Core.Commands;
using Scorponok.Gateway.Pagamento.Domain.Core.Notifications;
using Scorponok.Gateway.Pagamento.Domain.Interfaces;
using Scorponok.Gateway.Pagamento.Domain.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.CommandHandlers;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.CommandHandlers.Commands;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IRespository;
using System;
using Xunit;
using FluentAssertions;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IService;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Commands
{
    public class CancelamentoCommandHandlerTests
    {
        private Mock<IPedidoRepository> _mockIPedidoRepository;
        private Mock<IUnitOfWork> _mockIUnitOfWork;
        private Mock<IBus> _mockIBus;
        private Mock<IDomainNotificationHandler<DomainNotification>> _mockNotification;
        private Mock<IPedidoService> _mockPedidoService;

        public CancelamentoCommandHandlerTests()
        {
            _mockIPedidoRepository = new Mock<IPedidoRepository>();
            _mockIUnitOfWork = new Mock<IUnitOfWork>();
            _mockIBus = new Mock<IBus>();
            _mockNotification = new Mock<IDomainNotificationHandler<DomainNotification>>();
            _mockPedidoService = new Mock<IPedidoService>();
        }

        [Theory, InlineData("A0000548227", 1233)]
        public void Realiza_uma_cancelar(string identificadorPedido, int valorEmCentavos)
        {
            var guid = Guid.NewGuid();

            #region Arrange's

            var transacao = Builder<Transaction>
                .CreateNew()
                    .With(x => x.ValorCentavos, valorEmCentavos)
                    .With(x => x.Status, "Autorizado")
                .Build();

            var cartaoCredito = Builder<FormaPagamentoCartaoCredito>
                .CreateNew()
                    .Do(x => x.AdicionaTransacao(transacao))
                .Build();

            var formaPagamento = Builder<FormaPagamento>
                .CreateNew()
                    //.With(x => x.CartaoCredito, cartaoCredito)
                .Build();

            var pedido = Builder<Pedido>
                .CreateNew()
                    .With(x => x.Id, guid)
                    .With(x => x.FormaPagamento, formaPagamento)
                    .With(x => x.IdentificadorPedido, "A0000548227")
                .Build();


            #endregion

            #region Stub's

            _mockIPedidoRepository.Setup(x => x.ObterPor(guid)).Returns(pedido);
            _mockIUnitOfWork.Setup(x => x.Commit()).Returns(new CommandResult(true));

            #endregion

            #region Act

            var theEvent = new CancelarPedidoEventCommand(guid, valorEmCentavos);
            var command = new PedidoCommandHandler(_mockIPedidoRepository.Object, _mockIUnitOfWork.Object, _mockIBus.Object, _mockPedidoService.Object, _mockNotification.Object);
            command.Handle(theEvent);

            #endregion

            #region Assert's 

            pedido.FormaPagamento.Should().NotBeNull();
            //pedido.FormaPagamento.CartaoCredito.Should().NotBeNull();
            //pedido.FormaPagamento.CartaoCredito.Transactions.Should().HaveCount(1);
            //pedido.FormaPagamento.CartaoCredito.Transactions[0].Status.Should().Be("Cancelada");
            //pedido.FormaPagamento.CartaoCredito.Transactions[0].ValorCentavos.Should().Be(valorEmCentavos);

            _mockIPedidoRepository.Verify(x => x.ObterPor(guid), Times.Once);
            _mockIUnitOfWork.Verify(x => x.Commit(), Times.Once);
            #endregion

        }
    }
}
