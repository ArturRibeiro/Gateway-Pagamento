﻿namespace Scorponok.Gateway.Pagamento.Domain.Models.FormaPagamentos
{
    public class Boleto : FormaPagamento
    {
        public string Name { get; set; }

        public override string Tipo => "Boleto";
    }
}
