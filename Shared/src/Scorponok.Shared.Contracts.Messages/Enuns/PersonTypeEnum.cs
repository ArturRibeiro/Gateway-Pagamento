using System.Runtime.Serialization;

namespace Scorponok.Shared.Contracts.Messages.Enuns {

    /// <summary>
    /// Identifica se é pessoa física ou jurídica
    /// </summary>
    [DataContract]
    public enum PersonTypeEnum {

        /// <summary>
        /// Pessoa física
        /// </summary>
        [EnumMember]
        Person = 1,

        /// <summary>
        /// Pessoa jurídica
        /// </summary>
        [EnumMember]
        Company = 2
    }
}