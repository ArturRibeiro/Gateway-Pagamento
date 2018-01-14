using System;
using System.Runtime.Serialization;
using Scorponok.Gateway.Pagamento.Services.Cliente.Messages.EnumTypes;

namespace Scorponok.Gateway.Pagamento.Services.Cliente.Messages {

    /// <summary>
    /// Solicitação de recorrência
    /// </summary>
    [DataContract(Name = "Recurrency", Namespace = "")]
    public class Recurrency {

        #region Frequency

        /// <summary>
        /// Frequência da recorrência
        /// </summary>
        [DataMember(Name = "Frequency")]
        private string FrequencyField {
            get {
                return this.Frequency.ToString();
            }
            set {
                this.Frequency = (FrequencyEnum)Enum.Parse(typeof(FrequencyEnum), value);
            }
        }

        /// <summary>
        /// Frequência da recorrência
        /// </summary>
        public FrequencyEnum Frequency { get; set; }

        #endregion

        /// <summary>
        /// Intervalo de recorrência
        /// </summary>
        [DataMember]
        public int Interval { get; set; }

        #region DateToStartBilling

        /// <summary>
        /// Data da primeira cobrança
        /// </summary>
        [DataMember(Name = "DateToStartBilling", EmitDefaultValue = false)]
        private string DateToStartBillingField {
            get {
                return this.DateToStartBilling.Value.ToString(ServiceConstants.DATE_TIME_FORMAT);
            }
            set {
                if (value == null) {
                    this.DateToStartBilling = null;
                }
                else {
                    this.DateToStartBilling = DateTime.ParseExact(value, ServiceConstants.DATE_TIME_FORMAT, null);
                }
            }
        }

        /// <summary>
        /// Data da primeira cobrança
        /// </summary>
        public Nullable<DateTime> DateToStartBilling { get; set; }

        #endregion

        /// <summary>
        /// Total de recorrências
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Nullable<int> Recurrences { get; set; }

        /// <summary>
        /// Informa se será necessário efetuar o procedimento OneDollarAuth antes de registrar a recorrência
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Nullable<bool> OneDollarAuth { get; set; }
    }
}