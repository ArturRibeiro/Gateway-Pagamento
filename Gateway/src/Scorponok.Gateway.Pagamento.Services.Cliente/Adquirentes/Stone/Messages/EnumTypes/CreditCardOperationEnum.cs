using System.Runtime.Serialization;

namespace Scorponok.Gateway.Pagamento.Services.Cliente.Messages.EnumTypes {

    /// <summary>
    /// Tipo de operação de cartão de crédito
    /// </summary>
    [DataContract]
    public enum CreditCardOperationEnum {

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