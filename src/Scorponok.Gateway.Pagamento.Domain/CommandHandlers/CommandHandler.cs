using FluentValidation.Results;
using Scorponok.Gateway.Pagamento.Domain.Core.Bus;
using Scorponok.Gateway.Pagamento.Domain.Core.Notifications;
using Scorponok.Gateway.Pagamento.Domain.Interfaces;

namespace Scorponok.Gateway.Pagamento.Domain.CommandHandlers
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notification;

        public CommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notification)
        {
            _uow = uow;
            _bus = bus;
            _notification = notification;
        }

        protected void NotifyErrors(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                _bus.RaiseEvent(new DomainNotification(error.PropertyName, error.ErrorMessage));
        }

        protected bool Commit()
        {
            if (_notification.HasNotifications()) return false;

            var commandResult = _uow.Commit();
            
            _bus.RaiseEvent(new DomainNotification("Commit", "Ocorreu um erro ao  salvar os dados no banco."));

            return commandResult.Success;
        }
    }
}
