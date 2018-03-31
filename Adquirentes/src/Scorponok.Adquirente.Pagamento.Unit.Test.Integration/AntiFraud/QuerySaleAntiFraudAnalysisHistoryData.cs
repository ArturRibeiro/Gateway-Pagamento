using System;
using System.Runtime.Serialization;
using Scorponok.Adquirente.Pagamento.Unit.Test.Integration.EnumTypes;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration
{

	/// <summary>
	/// Histórico de antifraude
	/// </summary>
	[DataContract(Name = "QuerySaleAntiFraudAnalysisHistory", Namespace = "")]
	public class QuerySaleAntiFraudAnalysisHistoryData
	{

		/// <summary>
		/// Status do antifraude
		/// </summary>
		[DataMember(Name = "AntiFraudAnalysisStatus")]
		public AntiFraudAnalysisStatus? AntiFraudAnalysisStatus { get; set; }


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
		public decimal? Score { get; set; }

		#region StatusChangedDate

		/// <summary>
		/// Data da alteração de status
		/// </summary>
		[DataMember(Name = "StatusChangedDate")]
		private string StatusChangedDateField
		{
			get
			{
				return this.StatusChangedDate.ToString(ServiceConstants.DATE_TIME_FORMAT);
			}
			set
			{
				this.StatusChangedDate = DateTime.ParseExact(value, ServiceConstants.DATE_TIME_FORMAT, null);
			}
		}

		[IgnoreDataMember]
		public DateTime StatusChangedDate { get; set; }

		#endregion
	}
}