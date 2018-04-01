using System;
using System.Runtime.Serialization;

namespace Scorponok.Shared.Adquirentes.Contracts.Stone
{

    [DataContract(Namespace = "")]
    public abstract class BaseResponse {

        /// <summary>
        /// Relatório de erros.
        /// </summary>
        [DataMember]
        public ErrorReport ErrorReport { get; set; }

        /// <summary>
        /// Chave da loja. Utilizada para identificar a loja no gateway.
        /// </summary>
        [DataMember]
        public Guid MerchantKey { get; set; }

        /// <summary>
        /// Chave da requisição. Utilizada para identificar uma requisição específica no gateway.
        /// </summary>
        [DataMember]
        public Guid RequestKey { get; set; }

        /// <summary>
        /// Tempo de processamento do gateway. Não inclui tempo da adquirente.
        /// </summary>
        [DataMember]
        public long? InternalTime { get; set; }
    }
}