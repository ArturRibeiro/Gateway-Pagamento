using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Scorponok.Adquirentes.Contracts.Stone.Address;

namespace Scorponok.Adquirentes.Contracts.Stone.ShoppingCarts
{

	/// <summary>
	/// Carrinho de compra
	/// </summary>
	[DataContract(Name = "ShoppingCart", Namespace = "")]
	public class ShoppingCart
	{

		/// <summary>
		/// Preço do frete em centavos
		/// </summary>
		[DataMember]
		public int FreightCostInCents { get; set; }

		#region EstimatedDeliveryDate

		/// <summary>
		/// Data estimada para a entrega
		/// </summary>
		[DataMember(Name = "EstimatedDeliveryDate", EmitDefaultValue = false)]
		public DateTime? EstimatedDeliveryDate { get; set; }

		#endregion

		#region DeliveryDeadline

		/// <summary>
		/// Data limite para entrega
		/// </summary>
		[DataMember(Name = "DeliveryDeadline", EmitDefaultValue = false)]
		public DateTime? DeliveryDeadline { get; set; }

		#endregion

		/// <summary>
		/// Transportadora responsável pela entrega
		/// </summary>
		[DataMember(EmitDefaultValue = false)]
		public string ShippingCompany { get; set; }

		/// <summary>
		/// Endereço de entrega
		/// </summary>
		[DataMember(EmitDefaultValue = false)]
		public DeliveryAddress DeliveryAddress { get; set; }

		/// <summary>
		/// Itens do carrinho de compra
		/// </summary>
		[DataMember]
		public Collection<ShoppingCartItem> ShoppingCartItemCollection { get; set; }
	}
}