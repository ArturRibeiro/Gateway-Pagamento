using System.Runtime.Serialization;

namespace Scorponok.Shared.Adquirentes.Contracts.Stone.EnumTypes {

    /// <summary>
    /// Código de severidade
    /// </summary>
    [DataContract]
    public enum SeverityCodeEnum {

        /// <summary>
        /// Erro
        /// </summary>
        [EnumMember]
        Error = 1,

        /// <summary>
        /// Aviso
        /// </summary>
        [EnumMember]
        Warning = 2
    }
}