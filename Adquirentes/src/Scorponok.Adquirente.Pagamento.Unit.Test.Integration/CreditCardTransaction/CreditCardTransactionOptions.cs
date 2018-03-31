using System;
using System.Runtime.Serialization;
using Scorponok.Adquirente.Pagamento.Unit.Test.Integration.EnumTypes;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration {

    [DataContract(Name = "CreditCardTransactionOptions", Namespace = "")]
    public class CreditCardTransactionOptions {

        /// <summary>
        /// Código do método de pagamento
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int PaymentMethodCode { get; set; }

        /// <summary>
        /// Moeda. Opções: BRL, EUR, USD, ARS, BOB, CLP, COP, UYU, MXN, PYG
        /// </summary>
        [DataMember(Name = "CurrencyIso")]
        public CurrencyIso CurrencyIso { get; set; }

        /// <summary>
        /// Taxa para a companhia aérea
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public long IataAmountInCents { get; set; }

        /// <summary>
        /// Indica o tempo que a transação deverá esperar até ser capturada (contando a partir da data de criação)
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int CaptureDelayInMinutes { get; set; }

        /// <summary>
        /// Categoria da loja - MCC
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public long? MerchantCategoryCode { get; set; }

        /// <summary>
        /// Nome que aparecerá na fatura do comprador (caso não informado, o texto configurado no gateway será utilizado)
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string SoftDescriptorText { get; set; }

        /// <summary>
        /// Taxa de juros
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public decimal? InterestRate { get; set; }

        /// <summary>
        /// Indica se o limite extendido está habilitado
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool ExtendedLimitEnabled { get; set; }

        /// <summary>
        /// Código do limite extendido
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string ExtendedLimitCode { get; set; }

        /// <summary>
        /// Url para notificação da transação
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string NotificationUrl { get; set; }

        /// <summary>
        /// Indica se a transação vai precisar ser notificada
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool IsNotificationEnabled { get; set; }
    }
}