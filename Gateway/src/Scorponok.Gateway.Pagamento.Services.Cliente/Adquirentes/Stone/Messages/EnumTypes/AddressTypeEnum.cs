using System.Runtime.Serialization;

namespace Scorponok.Gateway.Pagamento.Services.Cliente.Messages.EnumTypes {

    /// <summary>
    /// Tipo de endereço
    /// </summary>
    [DataContract]
    public enum AddressTypeEnum {

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