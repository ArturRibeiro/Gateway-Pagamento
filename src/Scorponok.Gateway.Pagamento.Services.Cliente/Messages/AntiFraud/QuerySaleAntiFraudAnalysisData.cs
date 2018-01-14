using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Scorponok.Gateway.Pagamento.Services.Cliente.Messages.EnumTypes;

namespace Scorponok.Gateway.Pagamento.Services.Cliente.Messages {

    /// <summary>
    /// Consulta a dados de antifraude
    /// </summary>
    [DataContract(Name = "QuerySaleAntiFraudAnalysis", Namespace = "")]
    public class QuerySaleAntiFraudAnalysisData {

        /// <summary>
        /// Indica se o serviço de antifraude está habilitado
        /// </summary>
        [DataMember]
        public bool IsAntiFraudEnabled { get; set; }

        /// <summary>
        /// Código do serviço de antifraude
        /// </summary>
        [DataMember]
        public String AntiFraudServiceCode { get; set; }

        /// <summary>
        /// Nome do serviço de antifraude
        /// </summary>
        [DataMember]
        public String AntiFraudServiceName { get; set; }

        #region AntiFraudAnalysisStatus

        /// <summary>
        /// Status da análise de antifraude
        /// </summary>
        [DataMember(Name = "AntiFraudAnalysisStatus")]
        private string AntiFraudAnalysisStatusField {
            get {
                return this.AntiFraudAnalysisStatus.ToString();
            }
            set {
                this.AntiFraudAnalysisStatus = (AntiFraudAnalysisStatusEnum)Enum.Parse(typeof(AntiFraudAnalysisStatusEnum), value);
            }
        }

        /// <summary>
        /// Status da análise de antifraude
        /// </summary>
        public AntiFraudAnalysisStatusEnum AntiFraudAnalysisStatus { get; set; }

        #endregion

        /// <summary>
        /// Código de retorno do serviço de antifraude
        /// </summary>
        [DataMember]
        public String ReturnCode { get; set; }

        /// <summary>
        /// Status do retorno do antifraude
        /// </summary>
        [DataMember]
        public String ReturnStatus { get; set; }

        /// <summary>
        /// Mensagem de retorno do antifraude
        /// </summary>
        [DataMember]
        public String ReturnMessage { get; set; }

        /// <summary>
        /// Pontuação do comprador
        /// </summary>
        [DataMember]
        public Nullable<decimal> Score { get; set; }

        /// <summary>
        /// Histórico da análise de antifraude
        /// </summary>
        [DataMember]
        public Collection<QuerySaleAntiFraudAnalysisHistoryData> HistoryCollection { get; set; }
    }
}