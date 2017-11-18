using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models
{
    

    public class Transaction
    {
        private Transaction(int valorEmCentavos, string numeroCartaoCredito, string portador)
        {
            this.ValorCentavos = valorEmCentavos;


            this.CartaoCredito = CartaoCredito.Factory.Create(numeroCartaoCredito, portador);
        }

        /// <summary>
        /// Valor da transação em centavos. R$ 100,00 = 10000
        /// </summary>
        public int ValorCentavos { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public CartaoCredito CartaoCredito { get; private set; }


        /// <summary>
        /// Número de Parcelas
        /// </summary>
        public int NumeroParcelas { get; private set; }

        #region Factory
        public static class Factory
        {
            public static Transaction Create(int valorEmCentavos, string numeroCartaoCredito, string portador)
            {
                return new Transaction(valorEmCentavos, numeroCartaoCredito, portador);
            }
        }
        #endregion
    }
}
