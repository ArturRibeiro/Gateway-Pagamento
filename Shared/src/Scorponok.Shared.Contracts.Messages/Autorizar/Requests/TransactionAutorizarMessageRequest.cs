using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Shared.Contracts.Messages.Autorizar.Requests
{
    public class TransactionAutorizarMessageRequest
    {
        public List<TransactionMessageRequest> Transactions { get; set; }

        public OrderMessageRequest Order { get; set; }
    }
}
