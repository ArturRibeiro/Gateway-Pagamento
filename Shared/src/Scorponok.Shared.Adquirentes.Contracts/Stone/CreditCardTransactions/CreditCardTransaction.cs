using System;
using System.Runtime.Serialization;
using Scorponok.Shared.Adquirentes.Contracts.Stone.Sales;
using Scorponok.Shared.Adquirentes.Contracts.Stone.EnumTypes;
using Scorponok.Shared.Adquirentes.Contracts.Stone.Recurrencys;

namespace Scorponok.Shared.Adquirentes.Contracts.Stone.CreditCardTransactions
{

	/// <summary>
	/// Dados da transação de cartão de crédito
	/// </summary>
	[DataContract(Namespace = "")]
	public class CreditCardTransaction
	{

		/// <summary>
		/// Dados do cartão de crédito
		/// </summary>
		[DataMember]
		public CreditCard CreditCard { get; set; }

		/// <summary>
		/// Opções da transação.
		/// </summary>
		[DataMember(EmitDefaultValue = false)]
		public CreditCardTransactionOptions Options { get; set; }

		/// <summary>
		/// Dados de recorrência
		/// </summary>
		[DataMember(EmitDefaultValue = false)]
		public Recurrency Recurrency { get; set; }

		/// <summary>
		/// Valor original da transação em centavos
		/// </summary>
		[DataMember]
		public long AmountInCents { get; set; }

		/// <summary>
		/// Número de parcelas da transação.
		/// </summary>
		public int InstallmentCount { get; set; }

		/// <summary>
		/// Operação. Opções: Undefined, AuthOnly, AuthAndCapture, AuthAndCaptureWithDelay
		/// </summary>
		[DataMember(Name = "CreditCardOperation")]
		public CreditCardOperation CreditCardOperation { get; set; }

		/// <summary>
		/// Referência da transãção no sistema da loja
		/// </summary>
		[DataMember(Name = "TransactionReference")]
		public string TransactionReference { get; set; }

		/// <summary>
		/// Data de criação da transação no sistema da loja
		/// </summary>
		[DataMember]
		public DateTime? TransactionDateInMerchant { get; set; }

	}
}
