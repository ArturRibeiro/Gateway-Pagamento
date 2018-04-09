using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Scorponok.Adquirentes.Contracts.Stone.Sales
{

	/// <summary>
	/// Resposta da consulta de pedidos
	/// </summary>
	[DataContract(Name = "QuerySaleResponse", Namespace = "")]
	public class QuerySaleResponse : BaseResponse
	{

		/// <summary>
		/// Lista de vendas
		/// </summary>
		[DataMember]
		public List<SaleData> SaleDataCollection { get; set; } = new List<SaleData>();

		/// <summary>
		/// Indicador do total de vendas
		/// </summary>
		[DataMember]
		public int SaleDataCount { get; set; }
	}
}