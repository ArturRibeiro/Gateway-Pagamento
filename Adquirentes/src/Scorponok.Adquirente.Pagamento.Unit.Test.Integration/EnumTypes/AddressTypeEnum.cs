using System.Runtime.Serialization;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration.EnumTypes {

    /// <summary>
    /// Tipo de endereço
    /// </summary>
    [DataContract]
    public enum AddressType {

        /// <summary>
        /// Endereço comercial
        /// </summary>
        [EnumMember]
        Comercial,

        /// <summary>
        /// Endereço residencial
        /// </summary>
        [EnumMember]
        Residential
    }
}