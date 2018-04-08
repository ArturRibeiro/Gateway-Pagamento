using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Scorponok.Shared.Contracts.Messages.Autorizar.Requests
{

	public class AuthOnlyMessageRequest
	{
		public IList<CreditCardMessageRequest> Transactions { get; set; } = new List<CreditCardMessageRequest>();

        public OrderMessageRequest Order { get; set; }
    }
}
