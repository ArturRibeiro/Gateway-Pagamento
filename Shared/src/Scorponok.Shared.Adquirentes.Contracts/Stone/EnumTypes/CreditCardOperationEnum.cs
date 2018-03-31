using System.Runtime.Serialization;

namespace Scorponok.Shared.Adquirentes.Contracts.Stone.EnumTypes {

    /// <summary>
    /// Tipo de operação de cartão de crédito
    /// </summary>
    [DataContract]
    public enum CreditCardOperation {

        /// <summary>
        /// Somente autorizar
        /// </summary>
        [EnumMember]
        AuthOnly = 1,

        /// <summary>
        /// Autorizar e capturar
        /// </summary>
        [EnumMember]
        AuthAndCapture = 2,

        /// <summary>
        /// Autorizar e capturar com atraso
        /// </summary>
        [EnumMember]
        AuthAndCaptureWithDelay = 3,
    }
}