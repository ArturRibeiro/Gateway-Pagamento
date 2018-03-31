using System.Runtime.Serialization;

namespace Scorponok.Shared.Adquirentes.Contracts.Stone.EnumTypes {

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