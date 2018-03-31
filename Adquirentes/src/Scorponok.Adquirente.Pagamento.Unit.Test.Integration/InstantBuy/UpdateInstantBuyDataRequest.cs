using System;
using System.Runtime.Serialization;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration {

    [DataContract(Namespace = "")]
    public class UpdateInstantBuyDataRequest {

        /// <summary>
        /// Chave do Comprador
        /// </summary>
        [DataMember]
        public Guid BuyerKey { get; set; }
    }
}
