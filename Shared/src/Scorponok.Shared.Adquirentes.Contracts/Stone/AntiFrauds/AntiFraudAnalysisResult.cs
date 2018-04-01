using System;
using System.Runtime.Serialization;
using Scorponok.Shared.Adquirentes.Contracts.Stone.EnumTypes;

namespace Scorponok.Shared.Adquirentes.Contracts.Stone.AntiFrauds {

    /// <summary>
    /// Dados de antifraude
    /// </summary>
    [DataContract(Name = "AntiFraudAnalysisResult", Namespace = "")]
    public class AntiFraudAnalysisResult {

        /// <summary>
        /// Indica se a análise de antifraude está habilitada
        /// </summary>
        [DataMember]
        public bool IsAntiFraudEnabled { get; set; }

        /// <summary>
        /// Código do serviço de antifraude
        /// </summary>
        [DataMember]
        public String AntiFraudServiceCode { get; set; }

        #region AntiFraudAnalysisStatus

        /// <summary>
        /// Status da análise do serviço de antifraude
        /// </summary>
        [DataMember(Name = "AntiFraudAnalysisStatus")]
        public AntiFraudAnalysisStatus AntiFraudAnalysisStatus { get; set; }
		//private string AntiFraudAnalysisStatusField {
  //          get {
  //              return this.AntiFraudAnalysisStatus.ToString();
  //          }
  //          set {
  //              this.AntiFraudAnalysisStatus = (AntiFraudAnalysisStatusEnum)Enum.Parse(typeof(AntiFraudAnalysisStatusEnum), value);
  //          }
  //      }

        /// <summary>
        /// Status da análise do serviço de antifraude
        /// </summary>
        

        #endregion

        /// <summary>
        /// Código de retorno do antifraude
        /// </summary>
        [DataMember]
        public String ReturnCode { get; set; }

        /// <summary>
        /// Status de retorno do antifraude
        /// </summary>
        [DataMember]
        public String ReturnStatus { get; set; }

        /// <summary>
        /// Mensagem de retorno do antifraude
        /// </summary>
        [DataMember]
        public String Message { get; set; }

        /// <summary>
        /// Pontuação do pedido
        /// </summary>
        [DataMember]
        public decimal? Score { get; set; }

        /// <summary>
        /// Nome do serviço de antifraude
        /// </summary>
        [DataMember]
        public String AntiFraudServiceName { get; set; }
    }
}