using System;
using System.Runtime.Serialization;
using Scorponok.Gateway.Pagamento.Services.Cliente.Messages.EnumTypes;

namespace Scorponok.Gateway.Pagamento.Services.Cliente.Messages {

    [DataContract(Namespace = "")]
    public class CreateInstantBuyDataRequest {
        
        /// <summary>
        /// Endereço de cobrança
        /// </summary>
        [DataMember]
        public BillingAddress BillingAddress { get; set; }

        #region CreditCardBrand

        /// <summary>
        /// Bandeira do cartão de crédito
        /// </summary>
        [DataMember(Name = "CreditCardBrand")]
        private string CreditCardBrandField
        {
            get
            {
                return this.CreditCardBrand.ToString();
            }
            set
            {
                this.CreditCardBrand = (CreditCardBrandEnum)Enum.Parse(typeof(CreditCardBrandEnum), value);
            }
        }

        /// <summary>
        /// Bandeira do cartão de crédito
        /// </summary>
        public CreditCardBrandEnum CreditCardBrand { get; set; }

        #endregion

        /// <summary>
        /// Número do cartão de crédito
        /// </summary>
        [DataMember]
        public string CreditCardNumber { get; set; }

        /// <summary>
        /// Mês de expiração
        /// </summary>
        [DataMember]
        public int ExpMonth { get; set; }

        /// <summary>
        /// Ano de expiração
        /// </summary>
        [DataMember]
        public int ExpYear { get; set; }
        
        /// <summary>
        /// Nome do portador do cartão
        /// </summary>
        [DataMember]
        public string HolderName { get; set; }

        /// <summary>
        /// IsOneDollarAuth habilitado
        /// </summary>
        [DataMember]
        public bool IsOneDollarAuthEnabled { get; set; }

        /// <summary>
        /// Código de segurança
        /// </summary>
        [DataMember]
        public string SecurityCode { get; set; }

        /// <summary>
        /// Chave do Buyer
        /// </summary>
        [DataMember]
        public Guid BuyerKey { get; set; }
    }
}
