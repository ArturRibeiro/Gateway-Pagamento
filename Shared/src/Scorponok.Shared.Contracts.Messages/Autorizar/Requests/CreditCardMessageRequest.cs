namespace Scorponok.Shared.Contracts.Messages.Autorizar.Requests
{
    public class CreditCardMessageRequest
    {
        /// <summary>
        /// Bandeira do cartão do cliente
        /// </summary>
        public string CreditCardBrand
        {
            get;
            set;
        }

        /// <summary>
        /// Número do cartão do cliente. Informar apenas números.
        /// </summary>
        public string CreditCardNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Mês de expiração do cartão
        /// </summary>
        public int ExpMonth
        {
            get;
            set;
        }

        /// <summary>
        /// Ano de expiração do cartão
        /// </summary>
        public int ExpYear
        {
            get;
            set;
        }

        /// <summary>
        /// Nome do portador do cartão
        /// </summary>
        public string HolderName
        {
            get;
            set;
        }

        /// <summary>
        /// Código de segurança do cartão
        /// </summary>
        public string SecurityCode
        {
            get;
            set;
        }
    }
}
