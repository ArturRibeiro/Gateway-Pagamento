using System.Runtime.Serialization;

namespace Scorponok.Adquirentes.Contracts.Stone.Sales {

    [DataContract(Name = "RetrySaleOptions", Namespace = "")]
    public class RetrySaleOptions {

        /// <summary>
        /// Indica se o limite extendido está habilitado
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? ExtendedLimitEnabled { get; set; }

        /// <summary>
        /// Código do limite extendido
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string ExtendedLimitCode { get; set; }
    }
}
