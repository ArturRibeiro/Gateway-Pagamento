using System.Runtime.Serialization;

namespace Scorponok.Adquirentes.Contracts.Stone.InstantBuys {

    [DataContract(Namespace = "")]
    public class UpdateInstantBuyDataResponse : BaseResponse {

        /// <summary>
        /// Indicador de sucesso
        /// </summary>
        [DataMember]
        public bool Success { get; set; }
    }
}
