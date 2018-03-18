namespace Scorponok.Shared.Contracts.Messages.Autorizar.Requests
{
    public class TransactionMessageRequest
    {
        /// <summary>
        /// Valor da transação em centavos. R$ 100,00 = 10000
        /// </summary>
        public int AmountInCents
        {
            get;
            set;
        }


        public CreditCardMessageRequest CreditCard
        {
            get;
            set;
        }

        /// <summary>
        /// Tipo de operação a ser realizada
        /// </summary>
        public string CreditCardOperation
        {
            get;
            set;
        }

        /// <summary>
        /// Número de Parcelas
        /// </summary>
        public int InstallmentCount
        {
            get;
            set;
        }
    }
}
