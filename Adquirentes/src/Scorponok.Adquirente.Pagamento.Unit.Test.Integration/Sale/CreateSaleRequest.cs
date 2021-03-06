﻿using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration
{

	/// <summary>
	/// Criação de uma nova venda
	/// </summary>
	[DataContract(Name = "CreateSaleRequest", Namespace = "")]
	public class CreateSaleRequest
	{

		public CreateSaleRequest()
		{
			Options = new SaleOptions();
		}

		/// <summary>
		/// Lista de transações de cartão de crédito
		/// </summary>
		[DataMember(Name = "CreditCardTransactionCollection", EmitDefaultValue = false)]
		public Collection<CreditCardTransaction> CreditCardTransactionCollection { get; set; }

		/// <summary>
		/// Lista de transações de boleto
		/// </summary>
		[DataMember(EmitDefaultValue = false)]
		public Collection<BoletoTransaction> BoletoTransactionCollection { get; set; }

		/// <summary>
		/// Dados do pedido
		/// </summary>
		[DataMember(EmitDefaultValue = false)]
		public Order Order { get; set; }

		/// <summary>
		/// Dados do comprador
		/// </summary>
		[DataMember(EmitDefaultValue = false)]
		public Buyer Buyer { get; set; }

		/// <summary>
		/// Lista de carrinhos de compra
		/// </summary>
		[DataMember(EmitDefaultValue = false)]
		public Collection<ShoppingCart> ShoppingCartCollection { get; set; }

		/// <summary>
		/// Informações opcionais para a criação da venda
		/// </summary>
		[DataMember(EmitDefaultValue = false)]
		public SaleOptions Options { get; set; }

		/// <summary>
		/// Dados da loja
		/// </summary>
		[DataMember(EmitDefaultValue = false)]
		public Merchant Merchant { get; set; }

		/// <summary>
		/// Informações complementares da requisição
		/// </summary>
		[DataMember(EmitDefaultValue = false)]
		public RequestData RequestData { get; set; }
	}
}