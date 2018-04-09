using AutoMapper;
using Scorponok.Adquirentes.Contracts.Stone.CreditCardTransactions;
using Scorponok.Shared.Contracts.Messages.Autorizar.Requests;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration.Parsers.Profiles
{
	public class CreditCardProfile : Profile
	{
		public CreditCardProfile()
		{
			CreateMap<CreditCardMessageRequest, CreditCard>();
		}
	}
}