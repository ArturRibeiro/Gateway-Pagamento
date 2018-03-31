using System.Runtime.Serialization;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration.EnumTypes {

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