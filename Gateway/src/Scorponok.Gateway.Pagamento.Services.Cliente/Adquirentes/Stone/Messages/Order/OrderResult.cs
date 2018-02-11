using System;
using System.Runtime.Serialization;

namespace Scorponok.Gateway.Pagamento.Services.Cliente.Messages
{

    /// <summary>
    /// Dados do pedido
    /// </summary>
    [DataContract(Name = "OrderResult", Namespace = "")]
    public class OrderResult
    {

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

        /// <summary>
        /// Data de criação do pedido no gateway
        /// </summary>
        [DataMember(Name = "CreateDate")]
        public DateTime CreateDate { get; set; }
    }
}