using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration {

    /// <summary>
    /// Resposta da criação de uma nova venda
    /// </summary>
    [DataContract(Name = "CreateSaleResponse", Namespace = "")]
    public class CreateSaleResponse : BaseResponse {

        /// <summary>
        /// Lista de transações de cartão de crédito
        /// </summary>
        [DataMember]
        public Collection<CreditCardTransactionResult> CreditCardTransactionResultCollection { get; set; }

        /// <summary>
        /// Lista de transações de boleto
        /// </summary>
        [DataMember]
        public Collection<BoletoTransactionResult> BoletoTransactionResultCollection { get; set; }

        /// <summary>
        /// Dados de retorno do pedido
        /// </summary>
        [DataMember]
        public OrderResult OrderResult { get; set; }

        /// <summary>
        /// Chave do comprador. Utilizada para identificar um comprador no gateway
        /// </summary>
        [DataMember]
        public virtual Guid BuyerKey { get; set; }
    }
}