using System;
using System.Runtime.Serialization;
using Scorponok.Adquirente.Pagamento.Unit.Test.Integration.EnumTypes;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration {

    [DataContract(Name = "SaleOptions", Namespace = "")]
    public class SaleOptions {

        /// <summary>
        /// Habilita ou desabilita o serviço de anti fraude. Se for nulo o sistema utilizará as configurações da loja.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Nullable<bool> IsAntiFraudEnabled { get; set; }

        /// <summary>
        /// Define qual serviço de anti fraude será utilizado. Se for nulo ou zero o sistema utilizará as configurações da loja.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int AntiFraudServiceCode { get; set; }


        /// <summary>
        /// Define a quantidade de retentativas automáticas que deverão ser feitas. Se for nulo o sistema utilizará as configurações da loja.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Nullable<int> Retries { get; set; }

        #region CurrencyIso

        /// <summary>
        /// Moeda. Opções: BRL, EUR, USD, ARS, BOB, CLP, COP, UYU, MXN, PYG
        /// </summary>
        [DataMember(Name = "CurrencyIso", EmitDefaultValue = false)]
        private string CurrencyIsoField {
            get {
                if (this.CurrencyIso == null) { return null; }
                return this.CurrencyIso.ToString();
            }
            set {
                if (value == null) {
                    this.CurrencyIso = null;
                }
                else {
                    this.CurrencyIso = (CurrencyIso)Enum.Parse(typeof(CurrencyIso), value);
                }
            }
        }

        /// <summary>
        /// Moeda. Opções: BRL, EUR, USD, ARS, BOB, CLP, COP, UYU, MXN, PYG
        /// </summary>
        public Nullable<CurrencyIso> CurrencyIso { get; set; }

        #endregion
    }
}