using System.Runtime.Serialization;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration.EnumTypes {

    /// <summary>
    /// Moéda
    /// </summary>
    [DataContract]
    public enum CurrencyIso {

        /// <summary>
        /// Real
        /// </summary>
        [EnumMember]
        BRL = 986,

        /// <summary>
        /// Euro
        /// </summary>
        [EnumMember]
        EUR = 978,

        /// <summary>
        /// Dólar
        /// </summary>
        [EnumMember]
        USD = 840,

        /// <summary>
        /// Argentine peso
        /// </summary>
        [EnumMember]
        ARS = 032,

        /// <summary>
        /// Boliviano
        /// </summary>
        [EnumMember]
        BOB = 068,

        /// <summary>
        /// Chilean peso
        /// </summary>
        [EnumMember]
        CLP = 152,

        /// <summary>
        /// Colombian peso
        /// </summary>
        [EnumMember]
        COP = 170,

        /// <summary>
        /// Uruguayan peso
        /// </summary>
        [EnumMember]
        UYU = 858,

        /// <summary>
        /// Peso Mexicano
        /// </summary>
        [EnumMember]
        MXN = 484,

        /// <summary>
        /// Paraguayan guaraní
        /// </summary>
        [EnumMember]
        PYG = 600
    }
}