using System.Collections.Generic;
using System.Runtime.Serialization;
using Scorponok.Shared.Adquirentes.Contracts.Stone.CreditCardTransactions;

namespace Scorponok.Shared.Adquirentes.Contracts.Stone.Sales.Cancel
{
	[DataContract(Name = "CancelSaleResponse", Namespace = "")]
	public class CancelSaleResponse : BaseResponse
	{
		[DataMember]
		public List<CreditCardTransactionResult> CreditCardTransactionResultCollection { get; set; }
	}
}