using AutoMapper;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration.Parsers
{
	public class AuthOnlyMessageRequestProfile : Profile
	{
		public AuthOnlyMessageRequestProfile()
		{

		}
	}

	[TestFixture]
	public class AuthOnlyMessageRequestProfileTests
	{
		private readonly MapperConfiguration _config;

		public AuthOnlyMessageRequestProfileTests()
			=> _config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<AuthOnlyMessageRequestProfile>();
			});

		[Test]
		public void Mapear_AuthOnly_para_create_sale_request()
		{
			
		}
	}
}