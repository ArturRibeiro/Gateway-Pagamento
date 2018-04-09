using System.Runtime.Serialization;

namespace Scorponok.Shared.Contracts.Messages.Enuns {

    /// <summary>
    /// Paises
    /// </summary>
    [DataContract]
    public enum CountryEnum {

        /// <summary>
        /// Brasil
        /// </summary>
        [EnumMember]
        Brazil = 1,

        /// <summary>
        /// Estado Unidos
        /// </summary>
        [EnumMember]
        USA = 2,

        /// <summary>
        /// Argentina
        /// </summary>
        [EnumMember]
        Argentina = 3,

        /// <summary>
        /// Bolívia
        /// </summary>
        [EnumMember]
        Bolivia = 4,

        /// <summary>
        /// Chile
        /// </summary>
        [EnumMember]
        Chile = 5,

        /// <summary>
        /// Colombia
        /// </summary>
        [EnumMember]
        Colombia = 6,

        /// <summary>
        /// Uruguai
        /// </summary>
        [EnumMember]
        Uruguay = 7,

        /// <summary>
        /// México
        /// </summary>
        [EnumMember]
        Mexico = 8,

        //Paraguai
        [EnumMember]
        Paraguay = 9
    }
}