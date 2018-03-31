using System;
using System.Runtime.Serialization;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration {

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
        private string TransactionDateInMerchantField {
            get {
                if (this.TransactionDateInMerchant == null) { return null; }
                return this.TransactionDateInMerchant.Value.ToString(ServiceConstants.DATE_TIME_FORMAT);
            }
            set {
                if (value == null) {
                    this.TransactionDateInMerchant = null;
                }
                else {
                    this.TransactionDateInMerchant = DateTime.ParseExact(value, ServiceConstants.DATE_TIME_FORMAT, null);
                }
            }
        }

        /// <summary>
        /// Data da criação da transação no sistema da loja
        /// </summary>
        public Nullable<DateTime> TransactionDateInMerchant { get; set; }

        #endregion

        /// <summary>
        /// Opções da transação de boleto.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public BoletoTransactionOptions Options { get; set; }
    }
}