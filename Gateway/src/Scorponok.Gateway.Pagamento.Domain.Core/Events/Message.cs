﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Core.Events
{
    public abstract class Message
    {
        public string MessageType
        {
            get;
            protected set;
        }

        public Guid AggregateId
        {
            get;
            protected set;
        }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
