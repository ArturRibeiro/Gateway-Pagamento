using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Scorponok.Gateway.Pagamento.Services.Cliente.Messages.EnumTypes;

namespace Scorponok.Gateway.Pagamento.Services.Cliente.Messages {

    /// <summary>
    /// Dados do comprador
    /// </summary>
    [DataContract(Name = "Buyer", Namespace = "")]
    public class Buyer : Person {

        /// <summary>
        /// Chave do comprador. Utilizada para identificar um comprador no gateway
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Guid BuyerKey { get; set; }

        /// <summary>
        /// Referência do comprador no sistema da loja
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string BuyerReference { get; set; }

        /// <summary>
        /// Lista de endereços do comprador
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Collection<BuyerAddress> AddressCollection { get; set; }

        #region CreateDateInMerchant

        /// <summary>
        /// Data de criação do comprador no sistema da loja
        /// </summary>
        [DataMember(Name = "CreateDateInMerchant", EmitDefaultValue = false)]
        private string CreateDateInMerchantField {
            get {
                if (this.CreateDateInMerchant == null) { return null; }
                return this.CreateDateInMerchant.Value.ToString(ServiceConstants.DATE_TIME_FORMAT);
            }
            set {
                if (value == null) {
                    this.CreateDateInMerchant = null;
                }
                else {
                    this.CreateDateInMerchant = DateTime.ParseExact(value, ServiceConstants.DATE_TIME_FORMAT, null);
                }
            }
        }

        /// <summary>
        /// Data de criação do comprador no sistema da loja
        /// </summary>
        public Nullable<DateTime> CreateDateInMerchant { get; set; }

        #endregion

        #region LastBuyerUpdateInMerchant

        /// <summary>
        /// Data da última atualização do cadastro do comprador no sistema da loja
        /// </summary>
        [DataMember(Name = "LastBuyerUpdateInMerchant", EmitDefaultValue = false)]
        private string LastBuyerUpdateInMerchantField {
            get {
                if (this.LastBuyerUpdateInMerchant == null) { return null; }
                return this.LastBuyerUpdateInMerchant.Value.ToString(ServiceConstants.DATE_TIME_FORMAT);
            }
            set {
                if (value == null) {
                    this.LastBuyerUpdateInMerchant = null;
                }
                else {
                    this.LastBuyerUpdateInMerchant = DateTime.ParseExact(value, ServiceConstants.DATE_TIME_FORMAT, null);
                }
            }
        }

        /// <summary>
        /// Data da última atualização do cadastro do comprador no sistema da loja
        /// </summary>
        public Nullable<DateTime> LastBuyerUpdateInMerchant { get; set; }

        #endregion

        #region BuyerCategory

        /// <summary>
        /// Categoria do comprador
        /// </summary>
        [DataMember(Name = "BuyerCategory", EmitDefaultValue = false)]
        private string BuyerCategoryField {
            get {
                if (this.BuyerCategory == null) { return null; }
                return this.BuyerCategory.ToString();
            }
            set {
                if (value == null) {
                    this.BuyerCategory = null;
                }
                else {
                    this.BuyerCategory = (BuyerCategoryEnum)Enum.Parse(typeof(BuyerCategoryEnum), value);
                }
            }
        }

        /// <summary>
        /// Categoria do comprador
        /// </summary>
        public Nullable<BuyerCategoryEnum> BuyerCategory { get; set; }

        #endregion
    }
}