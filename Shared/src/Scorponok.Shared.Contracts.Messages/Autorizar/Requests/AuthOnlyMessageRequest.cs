using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Scorponok.Shared.Contracts.Messages.Autorizar.Requests
{
	public class AuthOnlyMessageRequest
	{
		[DataMember(Name = "SaleOptions")]
		public SaleOptionsMessageRequest SaleOptions { get; set; }

		[DataMember(Name = "Transactions")]
		public List<TransactionMessageRequest> Transactions { get; set; }

		[DataMember(Name = "Order")]
		public OrderMessageRequest Order { get; set; }
	}
}