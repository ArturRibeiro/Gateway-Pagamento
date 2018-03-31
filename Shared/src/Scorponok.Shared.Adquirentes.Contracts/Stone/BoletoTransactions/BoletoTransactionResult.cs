using System;
using System.Runtime.Serialization;
using Scorponok.Shared.Adquirentes.Contracts.Stone.EnumTypes;

namespace Scorponok.Shared.Adquirentes.Contracts.Stone.BoletoTransactions {

    /// <summary>
    /// Resultado da transação de boleto
    /// </summary>
    [DataContract(Name = "BoletoTransactionResult", Namespace = "")]
    public class BoletoTransactionResult {

        /// <summary>
        /// Url para visualização do boleto
        /// </summary>
        [DataMember]
        public string BoletoUrl { get; set; }

        /// <summary>
        /// Código de barras
        /// </summary>
        [DataMember]
        public string Barcode { get; set; }

        #region BoletoTransactionStatus

        /// <summary>
        /// Status do boleto
        /// </summary>
        [DataMember(Name = "BoletoTransactionStatus")]
        private string BoletoTransactionStatusField {
            get {
                return this.BoletoTransactionStatus.ToString();
            }
            set {
                this.BoletoTransactionStatus = (BoletoTransactionStatusEnum)Enum.Parse(typeof(BoletoTransactionStatusEnum), value);
            }
        }

        /// <summary>
        /// Status do boleto
        /// </summary>
        public BoletoTransactionStatusEnum BoletoTransactionStatus { get; set; }

        #endregion

        /// <summary>
        /// Chave da transação. Utilizada para identificar a transação de boleto no gateway
        /// </summary>
        [DataMember]
        public Guid TransactionKey { get; set; }

        /// <summary>
        /// Valor original da transação em centavos
        /// </summary>
        [DataMember]
        public long AmountInCents { get; set; }

        /// <summary>
        /// Número do documento
        /// </summary>
        [DataMember]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Identificador da transação no sistema da loja
        /// </summary>
        [DataMember]
        public string TransactionReference { get; set; }

        /// <summary>
        /// Indica se houve sucesso na geração do boleto
        /// </summary>
        [DataMember]
        public bool Success { get; set; }

        /// <summary>
        /// Número de identificação do boleto
        /// </summary>
        [DataMember]
        public string NossoNumero { get; set; }
    }
}