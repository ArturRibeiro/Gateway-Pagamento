using System.Runtime.Serialization;

namespace Scorponok.Gateway.Pagamento.Services.Cliente.Messages {

    /// <summary>
    /// Dados da loja
    /// </summary>
    [DataContract(Name = "Merchant", Namespace = "")]
    public class Merchant {

        /// <summary>
        /// Identificador da loja na plataforma
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string MerchantReference { get; set; }
    }
}