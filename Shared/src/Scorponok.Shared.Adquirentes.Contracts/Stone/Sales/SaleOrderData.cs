using System;
using System.Runtime.Serialization;

namespace Scorponok.Shared.Adquirentes.Contracts.Stone.Sales {

    /// <summary>
    /// Dados do pedido
    /// </summary>
    [DataContract(Name = "OrderData", Namespace = "")]
    public class OrderData {

        /// <summary>
        /// Número do pedido do sistema da loja
        /// </summary>
        [DataMember]
        public string OrderReference { get; set; }

        /// <summary>
        /// Chave do pedido. Utilizado para identificar um pedido no gateway
        /// </summary>
        [DataMember]
        public Guid OrderKey { get; set; }

        #region CreateDate

        /// <summary>
        /// Data de criação do pedido no gateway
        /// </summary>
        [DataMember(Name = "CreateDate")]
        private string CreateDateField {
            get {
                return this.CreateDate.ToString(ServiceConstants.DATE_TIME_FORMAT);
            }
            set {
                this.CreateDate = DateTime.ParseExact(value, ServiceConstants.DATE_TIME_FORMAT, null);
            }
        }

        /// <summary>
        /// Data de criação do pedido no gateway
        /// </summary>
        public DateTime CreateDate { get; set; }

        #endregion
    }
}