using System.Runtime.Serialization;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration.EnumTypes {

    /// <summary>
    /// Tipo de e-mail
    /// </summary>
    [DataContract]
    public enum EmailTypeEnum {

        /// <summary>
        /// Comercial
        /// </summary>
        [EnumMember]
        Comercial = 1,

        /// <summary>
        /// Pessoal
        /// </summary>
        [EnumMember]
        Personal = 2
    }
}