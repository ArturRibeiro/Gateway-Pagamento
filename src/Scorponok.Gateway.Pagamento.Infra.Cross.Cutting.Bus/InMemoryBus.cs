using Scorponok.Gateway.Pagamento.Domain.Core.Bus;
using System;
using Scorponok.Gateway.Pagamento.Domain.Core.Commands;
using Scorponok.Gateway.Pagamento.Domain.Core.Events;
using Scorponok.Gateway.Pagamento.Domain.Core.Notifications;

namespace Scorponok.Gateway.Pagamento.Infra.Cross.Cutting.Bus
{
    public sealed class InMemoryBus : IBus
    {
        public static Func<IServiceProvider> ContainerAccessor { get; set; }
        private static IServiceProvider Container => ContainerAccessor();
        
        public void RaiseEvent<T>(T theEvent) where T : Event
        {
            Publish(theEvent);
        }

        public void SendCommand<T>(T theCommand) where T : Command
        {
            Publish(theCommand);
        }

        private static void Publish<T>(T message) where T : Message
        {
            if (Container == null) return;

            var obj = Container.GetService(message.MessageType.Equals("DomainNotification")
                ? typeof(IDomainNotificationHandler<T>)
                : typeof(IHandler<T>));

            ((IHandler<T>)obj).Handle(message);
        }

    }
}
