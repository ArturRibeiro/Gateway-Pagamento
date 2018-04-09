using System;
using Scorponok.Gateway.Pagamento.Domain.Core.Models;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.VOs
{
    public class LojaVO : ValueObject<LojaVO>
    {
        private LojaVO(Guid lojaId, string lojaNome)
        {
            LojaId = lojaId;
            LojaNome = lojaNome;
        }

        public Guid LojaId { get; private set; }

        public string LojaNome { get; private set; }

        public static LojaVO Create(Guid lojaId, string lojaNome)
        {
            return new LojaVO(lojaId, lojaNome);
        }
    }
}