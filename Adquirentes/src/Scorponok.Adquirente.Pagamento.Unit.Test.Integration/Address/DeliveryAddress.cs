using System;
using System.Runtime.Serialization;
using Scorponok.Adquirente.Pagamento.Unit.Test.Integration.EnumTypes;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration {

    /// <summary>
    /// Informações de endereço
    /// </summary>
    [DataContract(Name = "DeliveryAddress", Namespace = "")]
    public class DeliveryAddress {

        /// <summary>
        /// País. Opções: Brazil, USA, Argentina, Bolivia, Chile, Colombia, Uruguay, Mexico, Paraguay
        /// </summary>
        [DataMember]
        public string Country { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        [DataMember]
        public string State { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        [DataMember]
        public string City { get; set; }

        /// <summary>
        /// Distrito
        /// </summary>
        [DataMember]
        public string District { get; set; }

        /// <summary>
        /// Logradouro
        /// </summary>
        [DataMember]
        public string Street { get; set; }

        /// <summary>
        /// Número
        /// </summary>
        [DataMember]
        public string Number { get; set; }

        /// <summary>
        /// Complemento
        /// </summary>
        [DataMember]
        public string Complement { get; set; }

        /// <summary>
        /// CEP
        /// </summary>
        [DataMember]
        public string ZipCode { get; set; }
    }
}