using System.Runtime.Serialization;

namespace Scorponok.Shared.Adquirentes.Contracts.Stone.EnumTypes {

    /// <summary>
    /// Categoria de e-commerce
    /// </summary>
    [DataContract]
    public enum EcommerceCategoryEnum {

        /// <summary>
        /// Business to Business 
        /// </summary>
        [EnumMember]
        B2B = 1,

        /// <summary>
        /// Business to Commerce
        /// </summary>
        [EnumMember]
        B2C = 2
    }
}