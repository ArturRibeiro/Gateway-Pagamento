using System.Runtime.Serialization;

namespace Scorponok.Gateway.Pagamento.Services.Cliente.Messages.EnumTypes {

    /// <summary>
    /// Status das transações de boleto
    /// </summary>
    [DataContract]
    public enum BoletoTransactionStatusEnum {

        /// <summary>
        /// Gerado
        /// </summary>
        [EnumMember]
        Generated = 1,

        /// <summary>
        /// Visualizado
        /// </summary>
        [EnumMember]
        Viewed = 2,

        /// <summary>
        /// Pago com valor abaixo
        /// </summary>
        [EnumMember]
        Underpaid = 3,

        /// <summary>
        /// Pago com valor maior
        /// </summary>
        [EnumMember]
        Overpaid = 4,

        /// <summary>
        /// Pago
        /// </summary>
        [EnumMember]
        Paid = 5,

        /// <summary>
        /// Cancelado
        /// </summary>
        [EnumMember]
        Voided = 6,

        /// <summary>
        /// Com erro
        /// </summary>
        [EnumMember]
        WithError = 99
    }
}