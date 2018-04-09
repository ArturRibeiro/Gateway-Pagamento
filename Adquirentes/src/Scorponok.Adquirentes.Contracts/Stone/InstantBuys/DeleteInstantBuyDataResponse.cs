using System.Runtime.Serialization;

namespace Scorponok.Adquirentes.Contracts.Stone.InstantBuys {

    [DataContract(Namespace = "")]
    public class DeleteInstantBuyDataResponse : BaseResponse {

        /// <summary>
        /// Indicador de sucesso
        /// </summary>
        [DataMember]
        public bool Success { get; set; }
    }
}
