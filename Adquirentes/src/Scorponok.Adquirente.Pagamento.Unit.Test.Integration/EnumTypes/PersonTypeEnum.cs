using System.Runtime.Serialization;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration.EnumTypes {

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