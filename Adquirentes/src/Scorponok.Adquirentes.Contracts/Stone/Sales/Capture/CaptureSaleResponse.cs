using System.Collections.Generic;
using System.Runtime.Serialization;
using Scorponok.Adquirentes.Contracts.Stone.CreditCardTransactions;

namespace Scorponok.Adquirentes.Contracts.Stone.Sales.Capture
{
	[DataContract(Name = "CaptureSaleResponse", Namespace = "")]
	public class CaptureSaleResponse : BaseResponse
	{
		[DataMember]
		public List<CreditCardTransactionResult> CreditCardTransactionResultCollection { get; set; }
	}
}