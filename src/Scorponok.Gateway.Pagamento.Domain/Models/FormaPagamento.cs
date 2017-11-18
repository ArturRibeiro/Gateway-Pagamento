using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models
{
    public class FormaPagamento
    {
        public readonly FormaPagamentoCartaoCredito CartaoCredito = new FormaPagamentoCartaoCredito();
        public readonly FormaPagamentoBoleto Boleto = new FormaPagamentoBoleto();
        public readonly FormaPagamentoDebitoOnline DebitoOnline = new FormaPagamentoDebitoOnline();
        public readonly FormaPagamentoPayPal PayPal = new FormaPagamentoPayPal();
    }
}
