using System;
using System.Runtime.Serialization;

namespace Scorponok.Gateway.Pagamento.Services.Cliente.Messages {

    [DataContract(Namespace = "")]
    public class CreateInstantBuyDataResponse : BaseResponse {

        /// <summary>
        /// Chave do InstantBuy
        /// </summary>
        [DataMember]
        public Guid InstantBuyKey { get; set; }

        /// <summary>
        /// Sucesso no OneDollarAuth
        /// </summary>
        [DataMember]
        public bool OneDollarAuthSuccess { get; set; }

        /// <summary>
        /// Sucesso
        /// </summary>
        [DataMember]
        public bool Success { get; set; }

    }
}
