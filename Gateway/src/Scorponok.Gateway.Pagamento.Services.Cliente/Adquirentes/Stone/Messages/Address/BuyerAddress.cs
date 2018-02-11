using System;
using System.Runtime.Serialization;
using Scorponok.Gateway.Pagamento.Services.Cliente.Messages.EnumTypes;

namespace Scorponok.Gateway.Pagamento.Services.Cliente.Messages {

    /// <summary>
    /// Informações de endereço
    /// </summary>
    [DataContract(Name = "BuyerAddress", Namespace = "")]
    public class BuyerAddress {

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

        #region AddressType

        /// <summary>
        /// Tipo de endereço
        /// </summary>
        [DataMember(Name = "AddressType")]
        private string AddressTypeField {
            get {
                return this.AddressType.ToString();
            }
            set {
                this.AddressType = (AddressTypeEnum)Enum.Parse(typeof(AddressTypeEnum), value);
            }
        }

        /// <summary>
        /// Tipo de endereço
        /// </summary>
        public AddressTypeEnum AddressType { get; set; }

        #endregion
    }
}