using System;
using System.Runtime.Serialization;
using Scorponok.Shared.Adquirentes.Contracts.Stone.Sales;
using Scorponok.Shared.Adquirentes.Contracts.Stone.EnumTypes;
using Scorponok.Shared.Adquirentes.Contracts.Stone.InstantBuys;

namespace Scorponok.Shared.Adquirentes.Contracts.Stone.CreditCardTransactions {

    /// <summary>
    /// Resultado da transação de cartão de crédito
    /// </summary>
    [DataContract(Name = "CreditCardTransactionResultCollection", Namespace = "")]
    public class CreditCardTransactionResult {

        /// <summary>
        /// Dados do cartão de crédito
        /// </summary>
        //[DataMember]
        public CreditCardData CreditCard { get; set; }

        #region CreditCardTransactionStatus

        /// <summary>
        /// Status da transação
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
        /// Status da transação
        /// </summary>
        public CreditCardTransactionStatusEnum CreditCardTransactionStatus { get; set; }

        #endregion

        /// <summary>
        /// Tempo de processamento da transação na adquirente
        /// </summary>
        //[DataMember]
        public long ExternalTime { get; set; }

        /// <summary>
        /// Chave da transação. Utilizada para identificar a transação de cartão de crédito no gateway
        /// </summary>
        //[DataMember]
        public Guid TransactionKey { get; set; }

        /// <summary>
        /// Identificador da transação na adquirente
        /// </summary>
        //[DataMember]
        public string TransactionIdentifier { get; set; }

        /// <summary>
        /// Código de autorização
        /// </summary>
        //[DataMember]
        public string AuthorizationCode { get; set; }

        /// <summary>
        /// Identificador único gerado pela adquirente
        /// </summary>
        //[DataMember]
        public string UniqueSequentialNumber { get; set; }

        #region CreditCardOperation

        /// <summary>
        /// Operação da transação de cartão de crédito - Indica se deverá ser realizada uma captura automática da transação
        /// </summary>
        [DataMember(Name = "CreditCardOperation")]
        private string CreditCardOperationField {
            get {
                return this.CreditCardOperation.ToString();
            }
            set {
                this.CreditCardOperation = (CreditCardOperation)Enum.Parse(typeof(CreditCardOperation), value);
            }
        }

        /// <summary>
        /// Operação da transação de cartão de crédito - Indica se deverá ser realizada uma captura automática da transação
        /// </summary>
        public CreditCardOperation CreditCardOperation { get; set; }

        #endregion

        /// <summary>
        /// Valor total da transação em centavos
        /// </summary>
        //[DataMember]
        public long AmountInCents { get; set; }

        /// <summary>
        /// Valor autorizado em centavos
        /// </summary>
        //[DataMember]
        public long? AuthorizedAmountInCents { get; set; }

        /// <summary>
        /// Valor capturado em centavos
        /// </summary>
        //[DataMember]
        public long? CapturedAmountInCents { get; set; }

        /// <summary>
        /// Valor estornado em centavos
        /// </summary>
        //[DataMember]
        public long? RefundedAmountInCents { get; set; }

        /// <summary>
        /// Valor cancelado em centavos
        /// </summary>
        //[DataMember]
        public long? VoidedAmountInCents { get; set; }

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
        public DateTime? DueDate { get; set; }

        #endregion

        /// <summary>
        /// Referência da transação no sistema da loja
        /// </summary>
        //[DataMember]
        public string TransactionReference { get; set; }

        /// <summary>
        /// Código de retorno da adquirente
        /// </summary>
        //[DataMember]
        public string AcquirerReturnCode { get; set; }

        /// <summary>
        /// Mensagem de retorno da adquirente
        /// </summary>
        //[DataMember]
        public string AcquirerMessage { get; set; }

        /// <summary>
        /// Indica se houve sucesso no processamento
        /// </summary>
        //[DataMember]
        public bool Success { get; set; }

        /// <summary>
        /// Código da filiação da loja na adquirente
        /// </summary>
        //[DataMember]
        public String AffiliationCode { get; set; }

        /// <summary>
        /// Nome do método de pagamento
        /// </summary>
        //[DataMember]
        public String PaymentMethodName { get; set; }

        /// <summary>
        /// Nome da adquirente
        /// </summary>
        //[DataMember]
        public String AcquirerName { get; set; }

        /// <summary>
        /// Chave da transação para adquirente, enviada pelo gateway
        /// </summary>
        //[DataMember]
        public string TransactionKeyToAcquirer { get; set; }

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
        public DateTime? CapturedDate { get; set; }

        #endregion

        /// <summary>
        /// Código de estabelecimento
        /// </summary>
        //[DataMember]
        public String EstablishmentCode { get; set; }
    }
}