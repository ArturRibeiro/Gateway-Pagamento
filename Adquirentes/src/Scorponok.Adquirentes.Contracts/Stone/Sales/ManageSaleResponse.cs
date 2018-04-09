using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Scorponok.Adquirentes.Contracts.Stone.CreditCardTransactions;

namespace Scorponok.Adquirentes.Contracts.Stone.Sales {

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