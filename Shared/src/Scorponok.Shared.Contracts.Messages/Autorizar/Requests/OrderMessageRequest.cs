using System.Runtime.Serialization;

namespace Scorponok.Shared.Contracts.Messages.Autorizar.Requests
{
	public class OrderMessageRequest
	{
		[DataMember(Name = "OrderReference")]
		public string OrderReference { get; set; }
	}
}