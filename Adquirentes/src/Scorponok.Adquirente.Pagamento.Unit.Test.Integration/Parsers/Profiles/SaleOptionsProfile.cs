using AutoMapper;
using Scorponok.Adquirentes.Contracts.Stone.Sales;
using Scorponok.Shared.Contracts.Messages.Autorizar.Requests;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration.Parsers.Profiles
{
	public class SaleOptionsProfile : Profile
	{
		public SaleOptionsProfile()
		{
			CreateMap<SaleOptionsMessageRequest, SaleOptions>();
		}
	}
}