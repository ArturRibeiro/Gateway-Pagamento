using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Scorponok.Shared.Adquirentes.Contracts
{

    [DataContract(Name = "ErrorReport", Namespace = "")]
    public class ErrorReport {

        /// <summary>
        /// Categoria do erro - ResquestError (Erro de requisição) / ThirdPartyError (Erro na adquirente) / SystemError (Erro do sistema)
        /// </summary>
        [DataMember]
        public string Category { get; set; }

        /// <summary>
        /// Colecao de erros
        /// </summary>
        [DataMember]
        public Collection<ErrorItem> ErrorItemCollection { get; set; }
    }
}

