using System.Runtime.Serialization;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration.EnumTypes {

    /// <summary>
    /// Bandeiras de cartão de crédito
    /// </summary>
    [DataContract]
    public enum CreditCardBrand {

        /// <summary>
        /// Visa
        /// </summary>
        [EnumMember]
        Visa = 1,

        /// <summary>
        /// MasterCard
        /// </summary>
        [EnumMember]
        Mastercard = 2,

        /// <summary>
        /// Hipercard
        /// </summary>
        [EnumMember]
        Hipercard = 3,

        /// <summary>
        /// Amex
        /// </summary>
        [EnumMember]
        Amex = 4,

        /// <summary>
        /// Diners
        /// </summary>
        [EnumMember]
        Diners = 5,

        /// <summary>
        /// Elo
        /// </summary>
        [EnumMember]
        Elo = 6,

        /// <summary>
        /// Aura
        /// </summary>
        [EnumMember]
        Aura = 7,

        /// <summary>
        /// Discover
        /// </summary>
        [EnumMember]
        Discover = 8,

        /// <summary>
        /// Casa Show
        /// </summary>
        [EnumMember]
        CasaShow = 9,

        /// <summary>
        /// Havan
        /// </summary>
        [EnumMember]
        Havan = 10,

        /// <summary>
        /// HugCard
        /// </summary>
        [EnumMember]
        HugCard = 11,

        /// <summary>
        /// AndarAki
        /// </summary>
        [EnumMember]
        AndarAki = 12,

        /// <summary>
        /// LearderCard
        /// </summary>
        [EnumMember]
        LeaderCard = 13
    }
}