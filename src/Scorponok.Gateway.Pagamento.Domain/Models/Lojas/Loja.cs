using System;
using Scorponok.Gateway.Pagamento.Domain.Core.Core.Models;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Lojas
{
    public class Loja : Entity
    {
        public Loja()
        {
            this.Nome = null;
            this.RazaoSocial = null;
            this.Cnpj = null;
            this.DataCriacao = DateTime.Now;
            this.DataAtualizacao = null;
        }

        public string Nome { get; private set; }

        public string RazaoSocial { get; private set; }

        public string Cnpj { get; private set; }

        public DateTime DataCriacao { get; private set; }

        public DateTime? DataAtualizacao { get; private set; }
    }
}