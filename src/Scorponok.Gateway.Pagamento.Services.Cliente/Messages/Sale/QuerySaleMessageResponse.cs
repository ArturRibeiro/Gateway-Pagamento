using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Scorponok.Gateway.Pagamento.Services.Cliente.Messages {

    /// <summary>
    /// Resposta da consulta de pedidos
    /// </summary>
    [DataContract(Name = "QuerySaleResponse", Namespace = "")]
    public class QuerySaleMessageResponse : BaseResponse {

        public QuerySaleMessageResponse() {
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