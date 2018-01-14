using System.Runtime.Serialization;

namespace Scorponok.Gateway.Pagamento.Services.Cliente.Messages.EnumTypes {

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