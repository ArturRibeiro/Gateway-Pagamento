using System;
using System.Runtime.Serialization;
using Scorponok.Adquirente.Pagamento.Unit.Test.Integration.EnumTypes;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration {

    /// <summary>
    /// Dados da transação de cartão de crédito
    /// </summary>
    [DataContract(Name = "CreditCardTransactionData", Namespace = "")]
    public class CreditCardTransactionData {

        /// <summary>
        /// Dados do cartão de crédito
        /// </summary>
        [DataMember]
        public CreditCardData CreditCard { get; set; }

        #region CreditCardTransactionStatus

        /// <summary>
        /// Status da transação de cartão de crédito
        /// </summary>
        [DataMember(Name = "CreditCardTransactionStatus")]
        private string CreditCardTransactionStatusField {
            get {
                return this.CreditCardTransactionStatus.ToString();
            }
            set {
                this.CreditCardTransactionStatus = (CreditCardTransactionStatusEnum)Enum.Parse(typeof(CreditCardTransactionStatusEnum), value);
            }
        }

        /// <summary>
        /// Status da transação de cartão de crédito
        /// </summary>
        public CreditCardTransactionStatusEnum CreditCardTransactionStatus { get; set; }

        #endregion

        /// <summary>
        /// Chave da transação. Utilizada para identificar a transação de cartão de crédito no gateway
        /// </summary>
        [DataMember]
        public Guid TransactionKey { get; set; }

        /// <summary>
        /// Identificador da transação gerado pela loja.
        /// </summary>
        [DataMember]
        public string TransactionIdentifier { get; set; }

        /// <summary>
        /// Código de autorização retornado pela adquirente
        /// </summary>
        [DataMember]
        public string AcquirerAuthorizationCode { get; set; }

        /// <summary>
        /// Identificador único retornado pela adquirente
        /// </summary>
        [DataMember]
        public string UniqueSequentialNumber { get; set; }

        /// <summary>
        /// Valor original da transação em centavos
        /// </summary>
        [DataMember]
        public long AmountInCents { get; set; }

        /// <summary>
        /// Valor autorizado em centavos
        /// </summary>
        [DataMember]
        public Nullable<long> AuthorizedAmountInCents { get; set; }

        /// <summary>
        /// Valor capturado em centavos
        /// </summary>
        [DataMember]
        public Nullable<long> CapturedAmountInCents { get; set; }

        /// <summary>
        /// Valor estornado em centavos
        /// </summary>
        [DataMember]
        public Nullable<long> RefundedAmountInCents { get; set; }

        /// <summary>
        /// Valor cancelado em centavos
        /// </summary>
        [DataMember]
        public Nullable<long> VoidedAmountInCents { get; set; }

        #region DueDate

        /// <summary>
        /// Data da recorrência (poderá ser futura)
        /// </summary>
        [DataMember(Name = "DueDate")]
        private string DueDateField {
            get {
                if (this.DueDate == null) { return null; }
                return this.DueDate.Value.ToString(ServiceConstants.DATE_TIME_FORMAT);
            }
            set {
                if (value == null) {
                    this.DueDate = null;
                }
                else {
                    this.DueDate = DateTime.ParseExact(value, ServiceConstants.DATE_TIME_FORMAT, null);
                }
            }
        }

        /// <summary>
        /// Data da recorrência (poderá ser futura)
        /// </summary>
        public Nullable<DateTime> DueDate { get; set; }

        #endregion

        /// <summary>
        /// Identificador da transação no sistema da loja
        /// </summary>
        [DataMember]
        public string TransactionReference { get; set; }

        #region CreateDate

        /// <summary>
        /// Data de criação da transação no gateway
        /// </summary>
        [DataMember(Name = "CreateDate")]
        private string CreateDateField {
            get {
                return this.CreateDate.ToString(ServiceConstants.DATE_TIME_FORMAT);
            }
            set {
                this.CreateDate = DateTime.ParseExact(value, ServiceConstants.DATE_TIME_FORMAT, null);
            }
        }

        /// <summary>
        /// Data de criação da transação no gateway
        /// </summary>
        public DateTime CreateDate { get; set; }

        #endregion

        /// <summary>
        /// Nome da adquirente que processou a transação
        /// </summary>
        [DataMember]
        public string AcquirerName { get; set; }

        /// <summary>
        /// Indica se é uma recorrência
        /// </summary>
        [DataMember]
        public bool IsReccurency { get; set; }

        /// <summary>
        /// Total de parcelas da transação
        /// </summary>
        [DataMember]
        public int InstallmentCount { get; set; }

        /// <summary>
        /// Código da filiação da loja na adquirente
        /// </summary>
        [DataMember]
        public string AffiliationCode { get; set; }

        /// <summary>
        /// Código do método de pagamento
        /// </summary>
        [DataMember]
        public string PaymentMethodName { get; set; }

        /// <summary>
        /// Chave da transação na adquirente, enviada pelo gateway
        /// </summary>
        [DataMember]
        public string TransactionKeyToAcquirer { get; set; }

        #region CaptureExpirationDate

        /// <summary>
        /// Data limite para a captura da transação na adquirente
        /// </summary>
        [DataMember(Name = "CaptureExpirationDate")]
        private string CaptureExpirationDateField {
            get {
                if (this.CaptureExpirationDate == null) { return null; }
                return this.CaptureExpirationDate.Value.ToString(ServiceConstants.DATE_TIME_FORMAT);
            }
            set {
                if (value == null) {
                    this.CaptureExpirationDate = null;
                }
                else {
                    this.CaptureExpirationDate = DateTime.ParseExact(value, ServiceConstants.DATE_TIME_FORMAT, null);
                }
            }
        }

        /// <summary>
        /// Data limite para a captura da transação na adquirente
        /// </summary>
        public Nullable<DateTime> CaptureExpirationDate { get; set; }

        #endregion

        /// <summary>
        /// Código de retorno da adquirente no momento da autorização.
        /// </summary>
        [DataMember]
        public string AcquirerReturnCode { get; set; }

        #region CapturedDate

        /// <summary>
        /// Data da captura
        /// </summary>
        [DataMember(Name = "CapturedDate")]
        private string CapturedDateField {
            get {
                if (this.CapturedDate == null) {
                    return null;
                }
                else {
                    return this.CapturedDate.Value.ToString(ServiceConstants.DATE_TIME_FORMAT);
                }
            }
            set {
                if (value == null) {
                    this.CapturedDate = null;
                }
                else {
                    this.CapturedDate = DateTime.ParseExact(value, ServiceConstants.DATE_TIME_FORMAT, null);
                }
            }
        }

        [IgnoreDataMember]
        public Nullable<DateTime> CapturedDate { get; set; }

        #endregion

        /// <summary>
        /// Código do estabelecimento na adquirente.
        /// </summary>
        [DataMember]
        public string EstablishmentCode { get; set; }
    }
}
