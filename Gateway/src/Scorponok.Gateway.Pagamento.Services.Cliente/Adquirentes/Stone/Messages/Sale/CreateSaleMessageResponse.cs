using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Scorponok.Gateway.Pagamento.Services.Cliente.Messages
{

    /// <summary>
    /// Resposta da criação de uma nova venda
    /// </summary>
    [DataContract(Name = "CreateSaleResponse", Namespace = "")]
    public class CreateSaleMessageResponse : BaseResponse
    {

        /// <summary>
        /// Lista de transações de cartão de crédito
        /// </summary>
        [DataMember]
        public object CreditCardTransactionResultCollection { get; set; }


        public Dictionary<string, Collection<CreditCardTransactionResult>> CreditCardTransactionResult { get; set; }

        /// <summary>
        /// Lista de transações de boleto
        /// </summary>
        //[DataMember]
        //public Collection<BoletoTransactionResult> BoletoTransactionResultCollection { get; set; }

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