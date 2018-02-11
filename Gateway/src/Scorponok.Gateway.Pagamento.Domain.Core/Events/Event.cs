using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Core.Events
{
    public abstract class Event : Message
    {
        public DateTime Timestamp
        {
            get;
            private set;
        }

        public Event()
        {
            this.Timestamp = DateTime.Now;
        }
    }
}
