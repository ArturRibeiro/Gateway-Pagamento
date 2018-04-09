using System.Runtime.Serialization;
using Scorponok.Shared.Contracts.Messages.Enuns;

namespace Scorponok.Shared.Contracts.Messages.Autorizar.Requests
{
	public class SaleOptionsMessageRequest
	{
		/// <summary>
		/// Habilita ou desabilita o serviço de anti fraude. Se for nulo o sistema utilizará as configurações da loja.
		/// </summary>
		[DataMember(EmitDefaultValue = false)]
		public bool? IsAntiFraudEnabled { get; set; }

		/// <summary>
		/// Define qual serviço de anti fraude será utilizado. Se for nulo ou zero o sistema utilizará as configurações da loja.
		/// </summary>
		[DataMember(EmitDefaultValue = false)]
		public int AntiFraudServiceCode { get; set; }

		/// <summary>
		/// Define a quantidade de retentativas automáticas que deverão ser feitas. Se for nulo o sistema utilizará as configurações da loja.
		/// </summary>
		[DataMember(EmitDefaultValue = false)]
		public int? Retries { get; set; }


		/// <summary>
		/// Moeda. Opções: BRL, EUR, USD, ARS, BOB, CLP, COP, UYU, MXN, PYG
		/// </summary>
		[DataMember(Name = "CurrencyIso")]
		public CurrencyIso? CurrencyIso { get; set; }
	}
}