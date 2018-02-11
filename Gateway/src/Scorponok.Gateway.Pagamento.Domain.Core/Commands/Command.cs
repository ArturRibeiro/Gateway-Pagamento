using Scorponok.Gateway.Pagamento.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Core.Commands
{
    public class Command : Message
    {
        public DateTime Timestamp
        {
            get;
            private set;
        }

        public Command()
        {
            this.Timestamp = new DateTime();
        }
    }
}
