using System;
using System.Runtime.Serialization;
using Scorponok.Gateway.Pagamento.Services.Cliente.Messages.EnumTypes;

namespace Scorponok.Gateway.Pagamento.Services.Cliente.Messages {

    /// <summary>
    /// Histórico de antifraude
    /// </summary>
    [DataContract(Name = "QuerySaleAntiFraudAnalysisHistory", Namespace = "")]
    public class QuerySaleAntiFraudAnalysisHistoryData {

        #region AntiFraudAnalysisStatus

        /// <summary>
        /// Status do antifraude
        /// </summary>
        [DataMember(Name = "AntiFraudAnalysisStatus")]
        private string AntiFraudAnalysisStatusField {
            get {
                if (this.AntiFraudAnalysisStatus == null) { return null; }
                return this.AntiFraudAnalysisStatus.Value.ToString(ServiceConstants.DATE_TIME_FORMAT);
            }
            set {
                if (value == null) {
                    this.AntiFraudAnalysisStatus = null;
                }
                else {
                    this.AntiFraudAnalysisStatus = (AntiFraudAnalysisStatusEnum)Enum.Parse(typeof(AntiFraudAnalysisStatusEnum), value);
                }
            }
        }

        /// <summary>
        /// Status da análise do serviço de anti fraude
        /// </summary>
        public Nullable<AntiFraudAnalysisStatusEnum> AntiFraudAnalysisStatus { get; set; }

        #endregion

        /// <summary>
        /// Código de retorno do serviço de anti fraude
        /// </summary>
        [DataMember]
        public String ReturnCode { get; set; }

        /// <summary>
        /// Status de retorno
        /// </summary>
        [DataMember]
        public String ReturnStatus { get; set; }

        /// <summary>
        /// Menssagem de retorno
        /// </summary>
        [DataMember]
        public String ReturnMessage { get; set; }

        /// <summary>
        /// Pontuação
        /// </summary>
        [DataMember]
        public Nullable<decimal> Score { get; set; }

        #region StatusChangedDate

        /// <summary>
        /// Data da alteração de status
        /// </summary>
        [DataMember(Name = "StatusChangedDate")]
        private string StatusChangedDateField {
            get {
                return this.StatusChangedDate.ToString(ServiceConstants.DATE_TIME_FORMAT);
            }
            set {
                this.StatusChangedDate = DateTime.ParseExact(value, ServiceConstants.DATE_TIME_FORMAT, null);
            }
        }

        [IgnoreDataMember]
        public DateTime StatusChangedDate { get; set; }

        #endregion
    }
}