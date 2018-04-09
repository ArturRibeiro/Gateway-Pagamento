using System.Runtime.Serialization;
using Scorponok.Shared.Contracts.Messages.Enuns;

namespace Scorponok.Shared.Contracts.Messages.Autorizar.Requests
{
	public class TransactionMessageRequest
	{
		[DataMember(Name = "Options")]
		public OptionsMessageRequest Options { get; set; }

		[DataMember(Name = "CreditCardOperation")]
		public CreditCardOperation CreditCardOperation { get; set; }

		[DataMember(Name = "AmountInCents")]
		public long AmountInCents { get; set; }

		[DataMember(Name = "CreditCard")]
		public CreditCardMessageRequest CreditCard { get; set; }

		[DataMember(Name = "InstallmentCount")]
		public long InstallmentCount { get; set; }
	}
}