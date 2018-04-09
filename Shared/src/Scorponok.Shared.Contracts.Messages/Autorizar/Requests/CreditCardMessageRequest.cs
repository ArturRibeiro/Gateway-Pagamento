using System;
using System.Runtime.Serialization;
using Scorponok.Shared.Contracts.Messages.Enuns;

namespace Scorponok.Shared.Contracts.Messages.Autorizar.Requests
{
	public class CreditCardMessageRequest
	{
		/// <summary>
		/// Chave do cartão de crédito. Utilizado para identificar um cartão de crédito no gateway
		/// </summary>
		[DataMember(EmitDefaultValue = false)]
		public Guid InstantBuyKey { get; set; }

		/// <summary>
		/// Número do cartão de crédito
		/// </summary>
		[DataMember(EmitDefaultValue = false)]
		public string CreditCardNumber { get; set; }

		/// <summary>
		/// Titular do cartão
		/// </summary>
		[DataMember(EmitDefaultValue = false)]
		public string HolderName { get; set; }

		/// <summary>
		/// Código de segurança - CVV
		/// </summary>
		[DataMember(EmitDefaultValue = false)]
		public string SecurityCode { get; set; }

		/// <summary>
		/// Mês de expiração do cartão de crédito
		/// </summary>
		[DataMember(EmitDefaultValue = false)]
		public int ExpMonth { get; set; }

		/// <summary>
		/// Ano de expiração do cartão de crédito
		/// </summary>
		[DataMember(EmitDefaultValue = false)]
		public int ExpYear { get; set; }

		/// <summary>
		/// Bandeira do cartão de crédito
		/// </summary>
		public CreditCardBrand CreditCardBrand { get; set; }
	}
}