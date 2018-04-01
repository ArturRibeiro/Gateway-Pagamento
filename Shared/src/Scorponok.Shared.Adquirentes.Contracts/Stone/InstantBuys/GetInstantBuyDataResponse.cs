using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Scorponok.Shared.Adquirentes.Contracts.Stone.InstantBuys {

    /// <summary>
    /// Dados de cartões de crédito de um comprador
    /// </summary>
    [DataContract(Name = "GetInstantBuyDataResponse", Namespace = "")]
    public class GetInstantBuyDataResponse : BaseResponse {

        /// <summary>
        /// Lista de cartões de crédito
        /// </summary>
        [DataMember]
        public Collection<CreditCardData> CreditCardDataCollection { get; set; }

        /// <summary>
        /// Total de cartões de crédito retornados
        /// </summary>
        [DataMember]
        public int CreditCardDataCount { get; set; }

        public GetInstantBuyDataResponse() {
            this.CreditCardDataCollection = new Collection<CreditCardData>();
        }
    }
}