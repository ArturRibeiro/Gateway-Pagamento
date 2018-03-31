using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Scorponok.Shared.Adquirentes.Contracts.Stone.CreditCardTransactions;

namespace Scorponok.Shared.Adquirentes.Contracts.Stone.Sales {

    /// <summary>
    /// Pedido de retentativa
    /// </summary>
    [DataContract(Name = "RetrySaleResquest", Namespace = "")]
    public class RetrySaleRequest {

        /// <summary>
        /// Chave do pedido. Utilizada para identificar um pedido no gateway
        /// </summary>
        [DataMember]
        public Guid OrderKey { get; set; }

        /// <summary>
        /// Opções da transação.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public RetrySaleOptions Options { get; set; }

        /// <summary>
        /// Lista de trasanções de cartão de crédito a serem retentadas
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Collection<RetrySaleCreditCardTransaction> RetrySaleCreditCardTransactionCollection { get; set; }
    }
}