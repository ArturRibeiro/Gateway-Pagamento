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
using Scorponok.Gateway.Pagamento.Domain.Models.FormaPagamentos;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IService;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas.IRespository;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Commands
{
    public class CancelamentoCommandHandlerTests
    {
        private Mock<IPedidoRepository> _mockIPedidoRepository;
        private Mock<ILojaRepository> _mockILojaRepository;
        private Mock<IUnitOfWork> _mockIUnitOfWork;
        private Mock<IBus> _mockIBus;
        private Mock<IDomainNotificationHandler<DomainNotification>> _mockNotification;
        
        public CancelamentoCommandHandlerTests()
        {
            _mockIPedidoRepository = new Mock<IPedidoRepository>();
            _mockILojaRepository = new Mock<ILojaRepository>();
            _mockIUnitOfWork = new Mock<IUnitOfWork>();
            _mockIBus = new Mock<IBus>();
            _mockNotification = new Mock<IDomainNotificationHandler<DomainNotification>>();
        }

        [Theory, InlineData("A0000548227", 1233)]
        public void Realiza_um_cancelamento(string identificadorPedido, int valorEmCentavos)
        {
            var guid = Guid.NewGuid();

            #region Arrange's

            var transacao = Builder<Transacao>
                .CreateNew()
                    //.With(x => x.ValorCentavos, valorEmCentavos)
                    .With(x => x.Status, TransacaoStatus.Autorizado)
                .Build();

            var cartaoCredito = Builder<FormaPagamentoCartao>
                .CreateNew()
                    //.Do(x => x.AdicionaTransacao(transacao))
                .Build();

            var formaPagamento = Builder<FormaPagamentoCartao>
                .CreateNew()
                    //.With(x => x.CartaoCredito, cartaoCredito)
                .Build();

            var pedido = Builder<Pedido>
                .CreateNew()
                    .With(x => x.Id, guid)
                    //.With(x => x.FormaPagamentoCartaoCredito, formaPagamento)
                    .With(x => x.IdentificadorPedido, "A0000548227")
                .Build();


            #endregion

            #region Stub's

            _mockIPedidoRepository.Setup(x => x.GetById(guid)).Returns(pedido);
            _mockIUnitOfWork.Setup(x => x.Commit()).Returns(new CommandResult(true));

            #endregion

            #region Act

            var theEvent = new CancelarPedidoEventCommand(guid, valorEmCentavos);
            var command = new PedidoCommandHandler(_mockIUnitOfWork.Object, _mockIBus.Object, _mockIPedidoRepository.Object, _mockNotification.Object);
            command.Handle(theEvent);

            #endregion

            #region Assert's 

           // pedido.FormaPagamentoCartaoCredito.Should().NotBeNull();
            //pedido.FormaPagamento.CartaoCredito.Should().NotBeNull();
            //pedido.FormaPagamento.CartaoCredito.Transactions.Should().HaveCount(1);
            //pedido.FormaPagamento.CartaoCredito.Transactions[0].Status.Should().Be("Cancelada");
            //pedido.FormaPagamento.CartaoCredito.Transactions[0].ValorCentavos.Should().Be(valorEmCentavos);

            //_mockIPedidoRepository.Verify(x => x.GetById(guid), Times.Once);
            //_mockIUnitOfWork.Verify(x => x.Commit(), Times.Once);
            #endregion

        }
    }
}
