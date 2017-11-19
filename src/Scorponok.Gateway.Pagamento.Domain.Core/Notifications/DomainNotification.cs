using Scorponok.Gateway.Pagamento.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Core.Notifications
{
    public class DomainNotification : Event
    {
        public Guid DomainNotificationId { get; private set; }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public string Version { get; private set; }

        public DomainNotification(string key, string value, int version = 1)
        {
            this.DomainNotificationId = Guid.NewGuid();
            this.Key = key;
            this.Value = value;
        }

    }
}
