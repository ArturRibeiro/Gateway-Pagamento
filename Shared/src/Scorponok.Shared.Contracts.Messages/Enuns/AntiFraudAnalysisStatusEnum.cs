using System.Runtime.Serialization;

namespace Scorponok.Shared.Contracts.Messages.Enuns {

    /// <summary>
    /// Status do Antifraude
    /// </summary>
    [DataContract]
    public enum AntiFraudAnalysisStatus {

        /// <summary>
        /// Pendente de análise de antifraude
        /// </summary>
        [EnumMember]
        PendingFraudAnalysisRequirement = 1,

        /// <summary>
        /// Pedido enviado para análise de antifraude
        /// </summary>
        [EnumMember]
        FraudAnalysisRequirementSent = 2,

        /// <summary>
        /// Aprovado
        /// </summary>
        [EnumMember]
        Approved = 3,

        /// <summary>
        /// Reprovado
        /// </summary>
        [EnumMember]
        Reproved = 4,

        /// <summary>
        /// Pendente de análise manual
        /// </summary>
        [EnumMember]
        PendingManualAnalysis = 5,

        /// <summary>
        /// Sem transação para análise
        /// </summary>
        [EnumMember]
        NoTransactionToAnalyse = 6,

        /// <summary>
        /// Erro na análise de antifraude
        /// </summary>
        [EnumMember]
        FraudAnalysisWithError = 7
    }
}