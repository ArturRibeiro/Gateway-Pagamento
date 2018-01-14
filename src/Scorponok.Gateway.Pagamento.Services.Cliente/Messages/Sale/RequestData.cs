using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Scorponok.Gateway.Pagamento.Services.Cliente.Messages.EnumTypes;

namespace Scorponok.Gateway.Pagamento.Services.Cliente.Messages {

    /// <summary>
    /// Dados complementares da requisição
    /// </summary>
    [DataContract(Name = "RequestData", Namespace = "")]
    public class RequestData {

        /// <summary>
        /// Identificador da origen do venda na loja
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Origin { get; set; }

        /// <summary>
        /// Identificador da sessão do usuário no sistema da loja (utilizado pelo serviço de anti fraude)
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string SessionId { get; set; }

        /// <summary>
        /// Endereço IP do cliente da loja
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string IpAddress { get; set; }

        /// <summary>
        /// Coleção dos itens genericos do pedido
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Collection<GenericData> GenericDataCollection { get; set; }

        #region EcommerceCategory

        /// <summary>
        /// Categoria da venda e-commerce. B2B ou B2C
        /// </summary>
        [DataMember(Name = "EcommerceCategory", EmitDefaultValue = false)]
        private string EcommerceCategoryField {
            get {
                if (this.EcommerceCategory == null) { return null; }
                return this.EcommerceCategory.ToString();
            }
            set {
                if (value == null) {
                    this.EcommerceCategory = null;
                }
                else {
                    this.EcommerceCategory = (EcommerceCategoryEnum)Enum.Parse(typeof(EcommerceCategoryEnum), value);
                }
            }
        }

        /// <summary>
        /// Categoria da venda e-commerce. B2B ou B2C
        /// </summary>
        public Nullable<EcommerceCategoryEnum> EcommerceCategory { get; set; }

        #endregion
    }
}