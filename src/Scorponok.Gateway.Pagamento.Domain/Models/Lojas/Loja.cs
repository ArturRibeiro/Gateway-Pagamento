using System;
using System.Collections.Generic;
using Scorponok.Gateway.Pagamento.Domain.Core.Core.Models;
using System.Collections.ObjectModel;
using System.Linq;
using Scorponok.Gateway.Pagamento.Infra.Cross.Cutting.Utility;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Lojas
{
    public class Loja : Entity
    {
        #region Construtores
        public Loja()
        {
            this.Nome = null;
            this.RazaoSocial = null;
            this.Cnpj = null;
            this.DataCriacao = DateTime.Now;
            this.DataAtualizacao = null;
            this.PedidosInternal = new List<Pedido>();
        }
        #endregion

        #region Propriedades
        public string Nome
        {
            get;
            private set;
        }

        public string RazaoSocial
        {
            get;
            private set;
        }

        public string Cnpj
        {
            get;
            private set;
        }

        public DateTime DataCriacao
        {
            get;
            private set;
        }

        public DateTime? DataAtualizacao
        {
            get;
            private set;
        }

        public IList<Pedido> PedidosInternal
        {
            get;
            private set;
        }

        public IReadOnlyCollection<Pedido> Pedidos => new ReadOnlyCollection<Pedido>(this.PedidosInternal.ToList()); 
        #endregion

        internal void AdicionaPedido(Pedido pedido)
        {
            Verify.ThrowIf(pedido == null, () => new ArgumentNullException("pedido"));

            this.PedidosInternal.Add(pedido);
        }
    }
}