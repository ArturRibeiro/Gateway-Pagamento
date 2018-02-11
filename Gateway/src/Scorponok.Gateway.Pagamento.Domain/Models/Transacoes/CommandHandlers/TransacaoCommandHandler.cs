using Scorponok.Gateway.Pagamento.Domain.CommandHandlers;
using Scorponok.Gateway.Pagamento.Domain.Core.Bus;
using Scorponok.Gateway.Pagamento.Domain.Core.Notifications;
using Scorponok.Gateway.Pagamento.Domain.Interfaces;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes.CommandHandlers.Commands;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes.ICommandHandler;
using System;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Transacoes.CommandHandlers
{
    public class TransacaoCommandHandler : CommandHandler, ITransacaoCommandHandler
    {
        #region Atributos
        private readonly IUnitOfWork _uow;
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notification;
        #endregion

        public TransacaoCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notification)
            : base(uow, bus, notification)
        {

        }

        public void Handle(AutorizarTransacaoEventCommand message)
        {
            //if (this.Commit()) _bus.RaiseEvent(new PedidoAutorizadoEvent(pedido.Id));

            this.Commit();
        }
    }
}
