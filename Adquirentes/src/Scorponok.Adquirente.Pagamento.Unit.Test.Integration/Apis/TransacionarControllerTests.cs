using System.Collections.Immutable;
using System.Net;
using FizzWare.NBuilder;
using FluentAssertions;
using NUnit.Framework;
using Scorponok.Adquirente.Web.UI.Api.Controllers;
using Scorponok.Shared.Contracts.Messages.Autorizar.Requests;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration.Apis
{
	[TestFixture, Category("Apis")]
	public class TransacionarControllerTests
	{
		[TestCase()]
		public void Deve_autorizar_uma_transacao_com_sucesso()
		{
			//Arrange's
			var authOnlyMessageRequest = Builder<AuthOnlyMessageRequest>
				.CreateNew()
					.With(x => x.Transactions, Builder<TransactionMessageRequest>
							.CreateListOfSize(1)
							.Build())
				.With(x => x.Order, Builder<OrderMessageRequest>
							.CreateNew()
							.Build())
				.Build();

			var controller = new TransacionarController();

			//Act's
			var result = controller.Autorizar(authOnlyMessageRequest);

			//Assert's
			result.Should().NotBeNull();
			result.Result.Should().NotBeNull();
			//result.Result.Should().Be(HttpStatusCode.OK);
		}
	}
}