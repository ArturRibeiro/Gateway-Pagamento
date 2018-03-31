using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration {

    /// <summary>
    /// Carrinho de compra
    /// </summary>
    [DataContract(Name = "ShoppingCart", Namespace = "")]
    public class ShoppingCart {

        /// <summary>
        /// Preço do frete em centavos
        /// </summary>
        [DataMember]
        public int FreightCostInCents { get; set; }

        #region EstimatedDeliveryDate

        /// <summary>
        /// Data estimada para a entrega
        /// </summary>
        [DataMember(Name = "EstimatedDeliveryDate", EmitDefaultValue = false)]
        private string EstimatedDeliveryDateField {
            get {
                if (this.EstimatedDeliveryDate == null) { return null; }
                return this.EstimatedDeliveryDate.Value.ToString(ServiceConstants.DATE_TIME_FORMAT);
            }
            set {
                if (value == null) {
                    this.EstimatedDeliveryDate = null;
                }
                else {
                    this.EstimatedDeliveryDate = DateTime.ParseExact(value, ServiceConstants.DATE_TIME_FORMAT, null);
                }
            }
        }

        /// <summary>
        /// Data estimada para a entrega
        /// </summary>
        public Nullable<DateTime> EstimatedDeliveryDate { get; set; }

        #endregion

        #region DeliveryDeadline

        /// <summary>
        /// Data limite para entrega
        /// </summary>
        [DataMember(Name = "DeliveryDeadline", EmitDefaultValue = false)]
        private string DeliveryDeadlineField {
            get {
                if (this.DeliveryDeadline == null) { return null; }
                return this.DeliveryDeadline.Value.ToString(ServiceConstants.DATE_TIME_FORMAT);
            }
            set {
                if (value == null) {
                    this.DeliveryDeadline = null;
                }
                else {
                    this.DeliveryDeadline = DateTime.ParseExact(value, ServiceConstants.DATE_TIME_FORMAT, null);
                }
            }
        }

        /// <summary>
        /// Data limite para entrega
        /// </summary>
        public Nullable<DateTime> DeliveryDeadline { get; set; }

        #endregion

        /// <summary>
        /// Transportadora responsável pela entrega
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string ShippingCompany { get; set; }

        /// <summary>
        /// Endereço de entrega
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DeliveryAddress DeliveryAddress { get; set; }

        /// <summary>
        /// Itens do carrinho de compra
        /// </summary>
        [DataMember]
        public Collection<ShoppingCartItem> ShoppingCartItemCollection { get; set; }
    }
}