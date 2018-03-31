using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Scorponok.Shared.Adquirentes.Contracts.Stone.CreditCardTransactions;

namespace Scorponok.Shared.Adquirentes.Contracts.Stone.Sales {

    /// <summary>
    /// Gerenciar Venda
    /// </summary>
    [DataContract(Name = "ManageSaleRequest", Namespace = "")]
    public class ManageSaleRequest {

        /// <summary>
        /// Coleções de transdações de cartão de crédito
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Collection<ManageCreditCardTransaction> CreditCardTransactionCollection { get; set; }

        /// <summary>
        /// Chave do pedido. Utilizada para identificar um pedido no gateway
        /// </summary>
        [DataMember]
        public Nullable<Guid> OrderKey { get; set; }
    }
}