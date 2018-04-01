using System;
using System.Runtime.Serialization;
using Scorponok.Shared.Adquirentes.Contracts.Stone.EnumTypes;

namespace Scorponok.Shared.Adquirentes.Contracts.Stone.InstantBuys {

    /// <summary>
    /// Dados do cartão de crédito
    /// </summary>
    [DataContract(Name = "CreditCard", Namespace = "")]
    public class CreditCardData {

        /// <summary>
        /// Número mascardo do cartão de crédito
        /// </summary>
        [DataMember]
        public string MaskedCreditCardNumber { get; set; }

        #region CreditCardBrand

        /// <summary>
        /// Bandeira do cartão de crédito
        /// </summary>
        [DataMember(Name = "CreditCardBrand")]
        private string CreditCardBrandField {
            get {
                return this.CreditCardBrand.ToString();
            }
            set {
                this.CreditCardBrand = (CreditCardBrand)Enum.Parse(typeof(CreditCardBrand), value);
            }
        }

        /// <summary>
        /// Bandeira do cartão de crédito
        /// </summary>
        public CreditCardBrand CreditCardBrand { get; set; }

        #endregion

        /// <summary>
        /// Chave do cartão de crédito. Utilizada para identificar um cartão de crédito no gateway
        /// </summary>
        [DataMember]
        public Guid InstantBuyKey { get; set; }

        /// <summary>
        /// Informa se o cartão de crédito expirou
        /// </summary>
        [DataMember]
        public bool IsExpiredCreditCard { get; set; }
    }
}