using System;
using System.Runtime.Serialization;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration {

    /// <summary>
    /// Pedido de cancelamento/captura da transação de cartão de crédito
    /// </summary>
    [DataContract(Name = "ManageCreditCardTransaction", Namespace = "")]
    public class ManageCreditCardTransaction {

        /// <summary>
        /// Chave da transação. Utilizada para identicar uma transação de cartão de crédito no gateway
        /// </summary>
        [DataMember]
        public Guid TransactionKey { get; set; }

        /// <summary>
        /// Identificador da transação no sistema da loja
        /// </summary>
        [DataMember]
        public string TransactionReference { get; set; }

        /// <summary>
        /// Valor da transação em centavos
        /// </summary>
        [DataMember]
        public long AmountInCents { get; set; }
    }
}