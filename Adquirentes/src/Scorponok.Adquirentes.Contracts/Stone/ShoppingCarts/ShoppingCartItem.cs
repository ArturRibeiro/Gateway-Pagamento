using System.Runtime.Serialization;

namespace Scorponok.Adquirentes.Contracts.Stone.ShoppingCarts {

    /// <summary>
    /// Itens do carrinho de compra
    /// </summary>
    [DataContract(Name = "ShoppingCartItem", Namespace = "")]
    public class ShoppingCartItem {

        /// <summary>
        /// Referência do item na loja
        /// </summary>
        [DataMember]
        public string ItemReference { get; set; }

        /// <summary>
        /// Quantidade de itens
        /// </summary>
        [DataMember]
        public int Quantity { get; set; }

        /// <summary>
        /// Custo unitártio
        /// </summary>
        [DataMember]
        public int UnitCostInCents { get; set; }

        /// <summary>
        /// Custo total em centavos
        /// </summary>
        [DataMember]
        public int TotalCostInCents { get; set; }

        /// <summary>
        /// Nome do produto
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Descrição do produto
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Total de desconto em centavos
        /// </summary>
        [DataMember]
        public long DiscountAmountInCents { get; set; }
    }
}