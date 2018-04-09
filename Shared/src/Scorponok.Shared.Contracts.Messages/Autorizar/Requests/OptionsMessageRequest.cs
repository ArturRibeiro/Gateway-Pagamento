using System.Runtime.Serialization;

namespace Scorponok.Shared.Contracts.Messages.Autorizar.Requests
{
	public class OptionsMessageRequest
	{
		[DataMember(Name = "CaptureDelayInMinutes")]
		public long CaptureDelayInMinutes { get; set; }

		[DataMember(Name = "CurrencyIso")]
		public string CurrencyIso { get; set; }

		[DataMember(Name = "ExtendedLimitEnabled")]
		public bool ExtendedLimitEnabled { get; set; }

		[DataMember(Name = "IataAmountInCents")]
		public long IataAmountInCents { get; set; }

		[DataMember(Name = "PaymentMethodCode")]
		public long PaymentMethodCode { get; set; }
	}
}