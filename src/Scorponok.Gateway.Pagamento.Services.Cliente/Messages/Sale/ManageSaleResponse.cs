using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Scorponok.Gateway.Pagamento.Services.Cliente.Messages {

    /// <summary>
    /// Resposta da ação de gerenciamento da venda
    /// </summary>
    [DataContract(Name = "ManageSaleResponse", Namespace = "")]
    public class ManageSaleResponse : BaseResponse {

        /// <summary>
        /// Coleção de transações de cartão de crédito
        /// </summary>
        [DataMember]
        public Collection<CreditCardTransactionResult> CreditCardTransactionResultCollection { get; set; }
    }
}