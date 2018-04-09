using System.Runtime.Serialization;

namespace Scorponok.Shared.Contracts.Messages.Enuns {

    /// <summary>
    /// Sexo
    /// </summary>
    [DataContract]
    public enum GenderEnum {
        
        /// <summary>
        /// Masculino
        /// </summary>
        [EnumMember]
        M = 1,

        /// <summary>
        /// Feminino
        /// </summary>
        [EnumMember]
        F = 2
    }
}