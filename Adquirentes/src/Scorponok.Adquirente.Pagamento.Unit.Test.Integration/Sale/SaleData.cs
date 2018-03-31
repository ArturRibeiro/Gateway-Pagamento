using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration {

    /// <summary>
    /// Entidade que representa a venda
    /// </summary>
    [DataContract(Name = "Sale", Namespace = "")]
    public class SaleData {

        /// <summary>
        /// Lista de transações de cartão de crédito
        /// </summary>
        [DataMember]
        public Collection<CreditCardTransactionData> CreditCardTransactionDataCollection { get; set; }

        /// <summary>
        /// Lista de transações de boleto
        /// </summary>
        [DataMember]
        public Collection<BoletoTransactionData> BoletoTransactionDataCollection { get; set; }

        /// <summary>
        /// Dados do pedido
        /// </summary>
        [DataMember]
        public OrderData OrderData { get; set; }

        /// <summary>
        /// Chave do comprador. Utilizada para identificar um comprador no gateway
        /// </summary>
        [DataMember]
        public virtual Guid BuyerKey { get; set; }

        /// <summary>
        /// Dados do serviço de antifraude
        /// </summary>
        [DataMember]
        public QuerySaleAntiFraudAnalysisData AntiFraudAnalysisData { get; set; }
    }
}