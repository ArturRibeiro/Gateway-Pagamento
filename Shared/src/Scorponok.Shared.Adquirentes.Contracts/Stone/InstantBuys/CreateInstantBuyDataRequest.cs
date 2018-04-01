using System;
using System.Runtime.Serialization;
using Scorponok.Shared.Adquirentes.Contracts.Stone.Address;
using Scorponok.Shared.Adquirentes.Contracts.Stone.EnumTypes;

namespace Scorponok.Shared.Adquirentes.Contracts.Stone.InstantBuys
{

	[DataContract(Namespace = "")]
	public class CreateInstantBuyDataRequest
	{

		/// <summary>
		/// Endereço de cobrança
		/// </summary>
		[DataMember]
		public BillingAddress BillingAddress { get; set; }

		#region CreditCardBrand

		/// <summary>
		/// Bandeira do cartão de crédito
		/// </summary>
		[DataMember(Name = "CreditCardBrand")]
		private string CreditCardBrandField
		{
			get
			{
				return this.CreditCardBrand.ToString();
			}
			set
			{
				this.CreditCardBrand = (CreditCardBrand)Enum.Parse(typeof(CreditCardBrand), value);
			}
		}

		/// <summary>
		/// Bandeira do cartão de crédito
		/// </summary>
		public CreditCardBrand CreditCardBrand { get; set; }

		#endregion

		/// <summary>
		/// Número do cartão de crédito
		/// </summary>
		[DataMember]
		public string CreditCardNumber { get; set; }

		/// <summary>
		/// Mês de expiração
		/// </summary>
		[DataMember]
		public int ExpMonth { get; set; }

		/// <summary>
		/// Ano de expiração
		/// </summary>
		[DataMember]
		public int ExpYear { get; set; }

		/// <summary>
		/// Nome do portador do cartão
		/// </summary>
		[DataMember]
		public string HolderName { get; set; }

		/// <summary>
		/// IsOneDollarAuth habilitado
		/// </summary>
		[DataMember]
		public bool IsOneDollarAuthEnabled { get; set; }

		/// <summary>
		/// Código de segurança
		/// </summary>
		[DataMember]
		public string SecurityCode { get; set; }

		/// <summary>
		/// Chave do Buyer
		/// </summary>
		[DataMember]
		public Guid BuyerKey { get; set; }
	}
}
