using Scorponok.Gateway.Pagamento.Domain.Core.Models;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.VOs
{
    public class CartaoVO : ValueObject<CartaoVO>
    {
        public CartaoVO(string cartaoBandeira, int cartaoExpiracao, string cartaoNumero, string cartaoPortador)
        {
            CartaoBandeira = cartaoBandeira;
            CartaoExpiracao = cartaoExpiracao;
            CartaoNumero = cartaoNumero;
            CartaoPortador = cartaoPortador;
        }

        public string CartaoBandeira { get; private set; }

        public string CartaoCvv { get; private set; }

        public int CartaoExpiracao { get; private set; }

        public string CartaoNumero { get; private set; }

        public string CartaoPortador { get; private set; }

        internal static CartaoVO Create(string bandeira, int expiracao, string numero, string portador)
        {
            return new CartaoVO(bandeira, expiracao, numero, portador);
        }
    }
}