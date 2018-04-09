using Scorponok.Gateway.Pagamento.Domain.Core.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.VOs
{
    public class TransacaoVO : ValueObject<CartaoVO>
    {
        public TransacaoVO(int transacaoNumeroParcelas, string transacaoStatus)
        {
            TransacaoNumeroParcelas = transacaoNumeroParcelas;
            TransacaoStatus = transacaoStatus;
        }

        public int TransacaoNumeroParcelas { get; private set; }

        public string TransacaoStatus { get; private set; }

        internal static TransacaoVO Create(int numeroParcelas, TransacaoStatus status)
        {
            return new TransacaoVO(numeroParcelas, status.ToString());
        }

        
    }
}