using System;
using System.Runtime.Serialization;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration {

    /// <summary>
    /// Dados do pedido
    /// </summary>
    [DataContract(Name = "OrderResult", Namespace = "")]
    public class OrderResult {

        /// <summary>
        /// Referência do pedido no sistema da loja
        /// </summary>
        [DataMember]
        public string OrderReference { get; set; }

        /// <summary>
        /// Chave do pedido. Utilizada para identificar um pedido no gateway
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