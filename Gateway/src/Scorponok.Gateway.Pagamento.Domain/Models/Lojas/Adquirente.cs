using Scorponok.Gateway.Pagamento.Domain.Core.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Lojas
{
	/// <summary>
	/// 
	/// </summary>
    public class Adquirente : Entity
    {
        #region Propriedades
        public string Nome
        {
            get;
            private set;
        }
        #endregion
        
        #region Factory
        public static class Factory
        {
            public static Adquirente Create(string nome)
            {
                return new Adquirente()
                {
                    Nome = nome
                };
            }
        }
        #endregion
    }
}
