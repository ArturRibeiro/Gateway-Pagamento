using System;
using System.Runtime.Serialization;
using Scorponok.Adquirentes.Contracts.Stone.Address;

namespace Scorponok.Adquirentes.Contracts.Stone.BoletoTransactions {

    /// <summary>
    /// Transação de boleto
    /// </summary>
    [DataContract(Name = "BoletoTransaction", Namespace = "")]
    public class BoletoTransaction {

        /// <summary>
        /// Valor do boleto em centavos
        /// </summary>
        [DataMember]
        public long AmountInCents { get; set; }

        /// <summary>
        /// Número do banco
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string BankNumber { get; set; }

        /// <summary>
        /// Isntruções a serem impressas no boleto
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Instructions { get; set; }

        /// <summary>
        /// Número do documento
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Identificador da transação no sistema da loja
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string TransactionReference { get; set; }

        /// <summary>
        /// Endereço de cobrança
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public BillingAddress BillingAddress { get; set; }

        #region TransactionDateInMerchant

        /// <summary>
        /// Data da criação da transação no sistema da loja
        /// </summary>
        [DataMember(Name = "TransactionDateInMerchant", EmitDefaultValue = false)]
        public DateTime? TransactionDateInMerchant { get; set; }

        #endregion

        /// <summary>
        /// Opções da transação de boleto.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public BoletoTransactionOptions Options { get; set; }
    }
}