using System.Runtime.Serialization;

namespace Scorponok.Shared.Adquirentes.Contracts.Stone.EnumTypes {

    /// <summary>
    /// Status das transações de cartão de crédito
    /// </summary>
    [DataContract]
    public enum CreditCardTransactionStatusEnum {

        /// <summary>
        /// Autorizado e pendente de captura
        /// </summary>
        [EnumMember]
        AuthorizedPendingCapture = 1,

        /// <summary>
        /// Não autorizado
        /// </summary>
        [EnumMember]
        NotAuthorized = 2,

        /// <summary>
        /// Previsão de chargeback
        /// </summary>
        [EnumMember]
        ChargebackPreview = 3,

        /// <summary>
        /// Previsão de estorno
        /// </summary>
        [EnumMember]
        RefundPreview = 4,

        /// <summary>
        /// Previsão de depósito
        /// </summary>
        [EnumMember]
        DepositPreview = 5,

        /// <summary>
        /// Capturado
        /// </summary>
        [EnumMember]
        Captured = 6,

        /// <summary>
        /// Capturado parcialmente
        /// </summary>
        [EnumMember]
        PartialCapture = 7,

        /// <summary>
        /// Estornado
        /// </summary>
        [EnumMember]
        Refunded = 8,

        /// <summary>
        /// Cancelado
        /// </summary>
        [EnumMember]
        Voided = 9,

        /// <summary>
        /// Depositado
        /// </summary>
        [EnumMember]
        Deposited = 10,

        /// <summary>
        /// Chargeback
        /// </summary>
        [EnumMember]
        Chargedback = 12,

        /// <summary>
        /// Pendente de cancelamento
        /// </summary>
        [EnumMember]
        PendingVoid = 13,

        /// <summary>
        /// Inválido
        /// </summary>
        [EnumMember]
        Invalid = 14,

        /// <summary>
        /// Autorizado parcialmente
        /// </summary>
        [EnumMember]
        PartialAuthorize = 15,

        /// <summary>
        /// Estornado parcialmente
        /// </summary>
        [EnumMember]
        PartialRefunded = 16,

        /// <summary>
        /// Capturado com valor a cima do original
        /// </summary>
        [EnumMember]
        OverCapture = 17,

        /// <summary>
        /// Parcialmente capturado
        /// </summary>
        [EnumMember]
        PartialVoid = 18,

        /// <summary>
        /// Pendente de estorno
        /// </summary>
        [EnumMember]
        PendingRefund = 19,

        /// <summary>
        /// Não agendado
        /// </summary>
        [EnumMember]
        UnScheduled = 20,

        /// <summary>
        /// Criado
        /// </summary>
        [EnumMember]
        Created = 21,

        /// <summary>
        /// Autorizado parcialmente
        /// </summary>
        [EnumMember]
        PartialAuthorized = 22,

        /// <summary>
        /// Não localizado na adquirente
        /// </summary>
        [EnumMember]
        NotFoundInAcquirer = 23,

        /// <summary>
        /// Pendente de autorização
        /// </summary>
        [EnumMember]
        PendingAuthorize = 24,

        /// <summary>
        /// Transação aguardando cancelamento
        /// </summary>
        [EnumMember]
        WaitingCancellation = 25,

        /// <summary>
        /// Com erro
        /// </summary>
        [EnumMember]
        WithError = 99
    }
}