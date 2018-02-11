using System.Runtime.Serialization;

namespace Scorponok.Gateway.Pagamento.Services.Cliente.Messages {

    /// <summary>
    /// Dados do pedido
    /// </summary>
    [DataContract(Name = "Order", Namespace = "")]
    public class Order {

        /// <summary>
        /// Identificador do pedido no sistema da loja
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string OrderReference { get; set; }
    }
}

