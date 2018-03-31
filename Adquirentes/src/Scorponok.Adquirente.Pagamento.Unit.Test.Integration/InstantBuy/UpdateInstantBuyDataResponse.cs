using System.Runtime.Serialization;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration {

    [DataContract(Namespace = "")]
    public class UpdateInstantBuyDataResponse : BaseResponse {

        /// <summary>
        /// Indicador de sucesso
        /// </summary>
        [DataMember]
        public bool Success { get; set; }
    }
}
