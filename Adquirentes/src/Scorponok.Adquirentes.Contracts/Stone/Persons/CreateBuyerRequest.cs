using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Scorponok.Adquirentes.Contracts.Stone.Address;
using Scorponok.Shared.Contracts.Messages.Enuns;

namespace Scorponok.Adquirentes.Contracts.Stone.Persons
{

    [DataContract(Namespace = "")]
    public class CreateBuyerRequest : Person {
        /// <summary>
        /// Lista de endereços do comprador
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Collection<BuyerAddress> AddressCollection { get; set; }

        #region BuyerCategory

        /// <summary>
        /// Categoria do comprador
        /// </summary>
        [DataMember(Name = "BuyerCategory", EmitDefaultValue = false)]
        private string BuyerCategoryField
        {
            get
            {
                if (this.BuyerCategory == null) { return null; }
                return this.BuyerCategory.ToString();
            }
            set
            {
                if (value == null) {
                    this.BuyerCategory = null;
                } else {
                    this.BuyerCategory = (BuyerCategoryEnum)Enum.Parse(typeof(BuyerCategoryEnum), value);
                }
            }
        }

        /// <summary>
        /// Categoria do comprador
        /// </summary>
        public BuyerCategoryEnum? BuyerCategory { get; set; }

        #endregion

        /// <summary>
        /// Referência do comprador no sistema da loja
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string BuyerReference { get; set; }

        #region CreateDateInMerchant

        /// <summary>
        /// Data de criação do comprador no sistema da loja
        /// </summary>
        [DataMember(Name = "CreateDateInMerchant", EmitDefaultValue = false)]
        public DateTime? CreateDateInMerchant { get; set; }

        #endregion

        #region LastBuyerUpdateInMerchant

        /// <summary>
        /// Data da última atualização do cadastro do comprador no sistema da loja
        /// </summary>
        [DataMember(Name = "LastBuyerUpdateInMerchant", EmitDefaultValue = false)]
        public DateTime? LastBuyerUpdateInMerchant { get; set; }

        #endregion
    }
}
