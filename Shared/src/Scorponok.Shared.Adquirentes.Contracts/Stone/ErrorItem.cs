using System.Runtime.Serialization;

namespace Scorponok.Shared.Adquirentes.Contracts.Stone
{

    [DataContract(Name = "ErrorItem", Namespace = "")]
    public class ErrorItem {

        /// <summary>
        /// Codigo identificador do erro
        /// </summary>
        [DataMember]
        public int ErrorCode { get; set; }

        /// <summary>
        /// Campo que originou o erro, usado por exemplo, nos erros gerados no contrato
        /// </summary>
        [DataMember]
        public string ErrorField { get; set; }

        /// <summary>
        /// Descrição do erro
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Tipifica o erro em warning ou error
        /// </summary>
        [DataMember]
        public string SeverityCode { get; set; }
    }
}