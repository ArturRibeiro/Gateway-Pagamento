using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration {

    /// <summary>
    /// Resposta da consulta de pedidos
    /// </summary>
    [DataContract(Name = "QuerySaleResponse", Namespace = "")]
    public class QuerySaleResponse : BaseResponse {

        public QuerySaleResponse() {
            this.SaleDataCollection = new Collection<SaleData>();
        }

        /// <summary>
        /// Lista de vendas
        /// </summary>
        [DataMember]
        public Collection<SaleData> SaleDataCollection { get; set; }

        /// <summary>
        /// Indicador do total de vendas
        /// </summary>
        [DataMember]
        public int SaleDataCount { get; set; }
    }
}