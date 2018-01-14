using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Scorponok.Gateway.Pagamento.Services.Cliente.Messages {

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