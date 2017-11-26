using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Transacoes
{
    public enum TransacaoStatus
    {
        Criado,
        Autorizado,
        Capturado,
        Cancelado
    }
}
