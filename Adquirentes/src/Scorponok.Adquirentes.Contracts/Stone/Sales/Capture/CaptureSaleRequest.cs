using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Scorponok.Adquirentes.Contracts.Stone.CreditCardTransactions;

namespace Scorponok.Adquirentes.Contracts.Stone.Sales.Capture
{
	[DataContract(Name = "CaptureSaleRequest", Namespace = "")]
	public class CaptureSaleRequest : BaseRequest
	{
		/// <summary>
		/// Lista de transações de cartão de crédito
		/// </summary>
		[DataMember(Name = "CreditCardTransactionCollection")]
		public List<CreditCardTransactionResult> CreditCardTransactionCollection { get; set; }

		[DataMember(Name = "OrderKey")]
		public Guid OrderKey { get; set; }
	}
}