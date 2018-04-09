using System;
using System.Runtime.Serialization;
using Scorponok.Shared.Contracts.Messages.Enuns;

namespace Scorponok.Adquirentes.Contracts.Stone.Recurrencys
{

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
        public DateTime? DateToStartBilling { get; set; }

        #endregion

        /// <summary>
        /// Total de recorrências
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? Recurrences { get; set; }

        /// <summary>
        /// Informa se será necessário efetuar o procedimento OneDollarAuth antes de registrar a recorrência
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool? OneDollarAuth { get; set; }
    }
}