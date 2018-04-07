using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using RestSharp;
using Scorponok.Shared.Adquirentes.Contracts.Stone;
using Scorponok.Shared.Adquirentes.Contracts.Stone.CreditCardTransactions;
using Scorponok.Shared.Adquirentes.Contracts.Stone.EnumTypes;
using Scorponok.Shared.Adquirentes.Contracts.Stone.Sales;
using Scorponok.Shared.Adquirentes.Contracts.Stone.Sales.Cancel;
using Xunit;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration
{
	public class GatewayStoneServiceClientTests
	{
		private readonly RestClient _client;
		private const string _merchantKey = "f2a1f485-cfd4-49f5-8862-0ebc438ae923";


		public GatewayStoneServiceClientTests() 
			=> _client = new RestClient("https://transaction.stone.com.br");


		[Theory, InlineData("4111111111111111", CreditCardBrand.Visa, 10, 2018, "123", "LUKE SKYWALKER")]
		public void Deve_criar_uma_Pre_Autorizacao_com_sucesso(string creditCardNumber, CreditCardBrand creditCardBrand, int expMonth, int expYear, string securityCode, string holderName)
		{
			//Arrange's

			//Act's
			var resultadoPreAutorizacao = CriaUmaPreautorizacao(creditCardNumber, creditCardBrand, expMonth, expYear, securityCode, holderName);
			
			//Assert's
			resultadoPreAutorizacao.StatusCode.Should().Be(HttpStatusCode.Created);
			resultadoPreAutorizacao.Data.MerchantKey.Should().Be(Guid.Parse(_merchantKey));
			resultadoPreAutorizacao.Data.RequestKey.Should().NotBe(Guid.Empty);

			var transacaoAutorizada = resultadoPreAutorizacao.Data.CreditCardTransactionResultCollection.ElementAt(0);

			transacaoAutorizada.AuthorizedAmountInCents.Should().Be(100);
			transacaoAutorizada.CreditCardOperation.Should().Be(CreditCardOperation.AuthOnly);
			transacaoAutorizada.CreditCardTransactionStatus.Should().Be(CreditCardTransactionStatusEnum.AuthorizedPendingCapture);
			transacaoAutorizada.AcquirerMessage.Should().Be("Simulator|Transação de simulação autorizada com sucesso");

			resultadoPreAutorizacao.Data.BuyerKey.Should().Be(Guid.Empty);
			resultadoPreAutorizacao.Data.OrderResult.Should().NotBeNull();
			resultadoPreAutorizacao.Data.OrderResult.OrderReference.Should().NotBeNull();
			resultadoPreAutorizacao.Data.OrderResult.OrderKey.Should().NotBe(Guid.Empty);
			resultadoPreAutorizacao.Data.OrderResult.CreateDate.Should().HaveDay(DateTime.Now.Day);
			resultadoPreAutorizacao.Data.OrderResult.CreateDate.Should().HaveMonth(DateTime.Now.Month);
			resultadoPreAutorizacao.Data.OrderResult.CreateDate.Should().HaveYear(DateTime.Now.Year);

			resultadoPreAutorizacao.Data.BoletoTransactionResultCollection.Should().NotBeNull();
			resultadoPreAutorizacao.Data.BoletoTransactionResultCollection.Should().HaveCount(0);

			resultadoPreAutorizacao.Data.CreditCardTransactionResultCollection.Should().NotBeNull();
			resultadoPreAutorizacao.Data.CreditCardTransactionResultCollection.Should().HaveCount(1);
		}
		
		[Theory, InlineData("4111111111111111", CreditCardBrand.Visa, 10, 2018, "123", "LUKE SKYWALKER")]
		public void Deve_cancela_uma_Transacao_com_sucesso(string creditCardNumber, CreditCardBrand creditCardBrand, int expMonth, int expYear, string securityCode, string holderName)
		{
			//Arrange's
			var preAutorizacao = CriaUmaPreautorizacao(creditCardNumber, creditCardBrand, expMonth, expYear, securityCode, holderName);

			preAutorizacao.Should().NotBeNull();
			preAutorizacao.Data.Should().NotBeNull();
			preAutorizacao.Data.OrderResult.Should().NotBeNull();
			preAutorizacao.Data.OrderResult.OrderKey.Should().NotBe(Guid.Empty);

			//Act's
			var resultadoDoCancelamento = CancelaUmaTransacao(preAutorizacao.Data.CreditCardTransactionResultCollection, preAutorizacao.Data.OrderResult.OrderKey);

			//Assert's
			resultadoDoCancelamento.StatusCode.Should().Be(HttpStatusCode.OK);
			resultadoDoCancelamento.Data.MerchantKey.Should().Be(Guid.Parse(_merchantKey));
			resultadoDoCancelamento.Data.RequestKey.Should().NotBe(Guid.Empty);
			resultadoDoCancelamento.Data.CreditCardTransactionResultCollection.Should().HaveCount(1);

			resultadoDoCancelamento.Data.CreditCardTransactionResultCollection.ElementAt(0)
				.AcquirerMessage.Should().Be("Simulator|Transação de simulação cancelada com sucesso");

		}

		[Theory, InlineData("4111111111111111", CreditCardBrand.Visa, 10, 2018, "123", "LUKE SKYWALKER")]
		public void Deve_capturar_uma_transacao_com_sucesso(string creditCardNumber, CreditCardBrand creditCardBrand,
			int expMonth, int expYear, string securityCode, string holderName)
		{
			//Arrange's
			var preAutorizacao = CriaUmaPreautorizacao(creditCardNumber, creditCardBrand, expMonth, expYear, securityCode, holderName);

			preAutorizacao.Should().NotBeNull();
			preAutorizacao.Data.Should().NotBeNull();
			preAutorizacao.Data.OrderResult.Should().NotBeNull();
			preAutorizacao.Data.OrderResult.OrderKey.Should().NotBe(Guid.Empty);

			//Act's
			var resultadoDaCaptura = CapturaUmaTransacao(preAutorizacao.Data.CreditCardTransactionResultCollection, preAutorizacao.Data.OrderResult.OrderKey);
			
			//Assert's
			resultadoDaCaptura.StatusCode.Should().Be(HttpStatusCode.OK);
			resultadoDaCaptura.Data.MerchantKey.Should().Be(Guid.Parse(_merchantKey));
			resultadoDaCaptura.Data.RequestKey.Should().NotBe(Guid.Empty);
			resultadoDaCaptura.Data.CreditCardTransactionResultCollection.Should().HaveCount(1);
			resultadoDaCaptura.Data.CreditCardTransactionResultCollection.ElementAt(0)
				.AuthorizedAmountInCents.Should()
				.Be(preAutorizacao.Data.CreditCardTransactionResultCollection.ElementAt(0).AuthorizedAmountInCents);

			var transacaoCancelada = resultadoDaCaptura.Data.CreditCardTransactionResultCollection.ElementAt(0);
			var transacaoAutorizada = preAutorizacao.Data.CreditCardTransactionResultCollection.ElementAt(0);

			transacaoCancelada.CapturedAmountInCents.Should().Be(transacaoAutorizada.AuthorizedAmountInCents);
			transacaoCancelada.CreditCardTransactionStatus.Should().Be(CreditCardTransactionStatusEnum.Captured);
			transacaoCancelada.AcquirerMessage.Should().Be("Simulator|Transação de simulação capturada com sucesso");
		}

		private IRestResponse<CreateSaleResponse> CriaUmaPreautorizacao(string creditCardNumber, CreditCardBrand creditCardBrand, int expMonth, int expYear, string securityCode, string holderName)
			=> Execute<CreateSaleResponse, CreateSaleRequest>
				(
					request: new CreateSaleRequest
					{
						CreditCardTransactionCollection = new Collection<CreditCardTransaction>
						{
							new CreditCardTransaction
							{
								CreditCard = new CreditCard
								{
									CreditCardNumber = creditCardNumber,
									CreditCardBrand = creditCardBrand,
									ExpMonth = expMonth,
									ExpYear = expYear,
									SecurityCode = securityCode,
									HolderName = holderName
								},
								CreditCardOperation = CreditCardOperation.AuthOnly,
								TransactionReference = Guid.NewGuid().ToString(),
								AmountInCents = 100,
								Options = new CreditCardTransactionOptions
								{
									PaymentMethodCode = 1,
									CurrencyIso = CurrencyIso.BRL
								}
							}
						}
					},
					uri: "/Sale",
					method: Method.POST
				);
		
		private IRestResponse<CaptureSaleResponse> CancelaUmaTransacao(List<CreditCardTransactionResult> creditCardTransactionCollection, Guid oderKey)
			=> Execute<CaptureSaleResponse, CaptureSaleRequest>
			(
				request: new CaptureSaleRequest
				{
					CreditCardTransactionCollection = creditCardTransactionCollection,
					OrderKey = oderKey
				},
				uri: "/Sale/Cancel",
				method: Method.POST

			);

		private IRestResponse<CaptureSaleResponse> CapturaUmaTransacao(List<CreditCardTransactionResult> creditCardTransactionCollection, Guid oderKey)
			=> Execute<CaptureSaleResponse, CaptureSaleRequest>
			(
				request: new CaptureSaleRequest
				{
					CreditCardTransactionCollection = creditCardTransactionCollection,
					OrderKey = oderKey
				},
				uri: "/Sale/Capture",
				method: Method.POST

			);

		private IRestResponse<TResponse> Execute<TResponse, TRequest>(TRequest request, string uri, Method method)
			where TRequest : BaseRequest
			where TResponse : BaseResponse
		{
			var rest = new RestRequest(uri, method) { RequestFormat = DataFormat.Json };
			rest.AddHeader("MerchantKey", _merchantKey);
			rest.AddBody(request);

			Task<IRestResponse<TResponse>> task = null;

			if (method == Method.POST) task = _client.ExecutePostTaskAsync<TResponse>(rest);

			task.Wait();

			return task.Result;
		}

	}
}
