using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using RestSharp;
using Scorponok.Adquirentes.Contracts.Stone;
using Scorponok.Adquirentes.Contracts.Stone.CreditCardTransactions;
using Scorponok.Adquirentes.Contracts.Stone.Sales;
using Scorponok.Adquirentes.Contracts.Stone.Sales.Capture;
using Scorponok.Shared.Contracts.Messages.Enuns;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration
{
	[TestFixture]
	public class GatewayStoneServiceClientTests
	{
		private readonly RestClient _client;
		private const string _merchantKey = "f2a1f485-cfd4-49f5-8862-0ebc438ae923";


		public GatewayStoneServiceClientTests()
			=> _client = new RestClient("https://transaction.stone.com.br");



		[TestCase("4111111111111111", CreditCardBrand.Visa, 10, 2018, "123", "LUKE SKYWALKER")]
		public void Deve_criar_uma_Pre_Autorizacao_com_sucesso(string creditCardNumber, CreditCardBrand creditCardBrand, int expMonth
			, int expYear, string securityCode, string holderName)
		{
			//Arrange's

			//Act's
			var resultadoPreAutorizacao = CriaUmaPreAutorizacao(creditCardNumber, creditCardBrand, expMonth, expYear, securityCode, holderName);

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

		[TestCase("4111111111111111", CreditCardBrand.Visa, 10, 2018, "123", "LUKE SKYWALKER")]
		public void Deve_criar_uma_Autorizacao_e_Capturar_com_sucesso(string creditCardNumber, CreditCardBrand creditCardBrand, int expMonth
			, int expYear, string securityCode, string holderName)
		{
			//Arrange's

			//Act's
			var resultadoPreAutorizacao = CriaUmaAutorizacaoECaptura(creditCardNumber, creditCardBrand, expMonth, expYear, securityCode, holderName);

			//Assert's
			resultadoPreAutorizacao.StatusCode.Should().Be(HttpStatusCode.Created);
			resultadoPreAutorizacao.Data.MerchantKey.Should().Be(Guid.Parse(_merchantKey));
			resultadoPreAutorizacao.Data.RequestKey.Should().NotBe(Guid.Empty);

			var transacaoAutorizada = resultadoPreAutorizacao.Data.CreditCardTransactionResultCollection.ElementAt(0);

			transacaoAutorizada.AuthorizedAmountInCents.Should().Be(100);
			transacaoAutorizada.CreditCardOperation.Should().Be(CreditCardOperation.AuthAndCapture);
			transacaoAutorizada.CreditCardTransactionStatus.Should().Be(CreditCardTransactionStatusEnum.Captured);
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

		[TestCase("4111111111111111", CreditCardBrand.Visa, 10, 2018, "123", "LUKE SKYWALKER")]
		public void Deve_cancela_uma_Transacao_com_sucesso(string creditCardNumber, CreditCardBrand creditCardBrand, int expMonth
			, int expYear, string securityCode, string holderName)
		{
			//Arrange's
			var preAutorizacao = CriaUmaPreAutorizacao(creditCardNumber, creditCardBrand, expMonth, expYear, securityCode, holderName);

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

		[TestCase("4111111111111111", CreditCardBrand.Visa, 10, 2018, "123", "LUKE SKYWALKER")]
		public void Deve_capturar_uma_transacao_com_sucesso(string creditCardNumber, CreditCardBrand creditCardBrand
			, int expMonth, int expYear, string securityCode, string holderName)
		{
			//Arrange's
			var preAutorizacao = CriaUmaPreAutorizacao(creditCardNumber, creditCardBrand, expMonth, expYear, securityCode, holderName);

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

		[TestCase(CreditCardOperation.AuthOnly, CreditCardBrand.Visa)]
		[TestCase(CreditCardOperation.AuthAndCapture, CreditCardBrand.Mastercard)]
		public void Consultar_uma_transacao_com_sucesso(CreditCardOperation operation, CreditCardBrand creditCardBrand)
		{
			//Arrange's
			var preAutorizacao = CriaUmaAutorizacao(operation: operation, creditCardBrand: creditCardBrand);
			preAutorizacao.Should().NotBeNull();
			preAutorizacao.Data.Should().NotBeNull();
			preAutorizacao.Data.OrderResult.Should().NotBeNull();
			preAutorizacao.Data.OrderResult.OrderKey.Should().NotBe(Guid.Empty);

			//act's
			var resultadoDaConsulta = ConsultaTransacao(preAutorizacao.Data.OrderResult.OrderReference);

			//Assert's
			resultadoDaConsulta.StatusCode.Should().Be(HttpStatusCode.OK);
			resultadoDaConsulta.Data.MerchantKey.Should().Be(Guid.Parse(_merchantKey));
			resultadoDaConsulta.Data.RequestKey.Should().NotBe(Guid.Empty);
			resultadoDaConsulta.Should().NotBeNull();
			resultadoDaConsulta.Data.SaleDataCollection.Should().HaveCount(1);
			var sale = resultadoDaConsulta.Data.SaleDataCollection.ElementAt(0);

			sale.CreditCardTransactionDataCollection.Should().HaveCount(1);
			var creditCardTransaction = sale.CreditCardTransactionDataCollection.ElementAt(0);

			creditCardTransaction.CreateDate.Date.Should().Be(DateTime.Now.Date);
			creditCardTransaction.CreditCard.CreditCardBrand.Should().Be(creditCardBrand);
			creditCardTransaction.TransactionKey.Should().Be(preAutorizacao.Data.CreditCardTransactionResultCollection.ElementAt(0).TransactionKey);
			creditCardTransaction.TransactionReference.Should().Be(preAutorizacao.Data.CreditCardTransactionResultCollection.ElementAt(0).TransactionReference);
			creditCardTransaction.UniqueSequentialNumber.Should().Be(preAutorizacao.Data.CreditCardTransactionResultCollection.ElementAt(0).UniqueSequentialNumber);
			creditCardTransaction.TransactionReference.Should().Be(preAutorizacao.Data.CreditCardTransactionResultCollection.ElementAt(0).TransactionReference);
			creditCardTransaction.TransactionReference.Should().Be(preAutorizacao.Data.CreditCardTransactionResultCollection.ElementAt(0).TransactionReference);
			creditCardTransaction.TransactionIdentifier.Should().Be(preAutorizacao.Data.CreditCardTransactionResultCollection.ElementAt(0).TransactionIdentifier);

		}


		private IRestResponse<CreateSaleResponse> CriaUmaAutorizacao(string creditCardNumber = "4111111111111111"
			, CreditCardBrand creditCardBrand = CreditCardBrand.Visa
			, int expMonth = 10
			, int expYear = 2018
			, string securityCode = "123"
			, string holderName = "LUKE SKYWALKER"
			, CreditCardOperation operation = CreditCardOperation.AuthOnly)
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
							CreditCardOperation = operation,
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

		private IRestResponse<CreateSaleResponse> CriaUmaPreAutorizacao(string creditCardNumber = "4111111111111111"
			, CreditCardBrand creditCardBrand = CreditCardBrand.Visa
			, int expMonth = 10
			, int expYear = 2018
			, string securityCode = "123"
			, string holderName = "LUKE SKYWALKER"
			, CreditCardOperation operation = CreditCardOperation.AuthOnly)
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
								CreditCardOperation = operation,
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

		private IRestResponse<CreateSaleResponse> CriaUmaAutorizacaoECaptura(string creditCardNumber, CreditCardBrand creditCardBrand, int expMonth, int expYear, string securityCode, string holderName)
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
							CreditCardOperation = CreditCardOperation.AuthAndCapture,
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

		private IRestResponse<QuerySaleResponse> ConsultaTransacao(string orderReference)
			=> Execute<QuerySaleResponse>
			(
				uri: $"/Sale/Query/OrderReference={orderReference}"
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

		private IRestResponse<TResponse> Execute<TResponse>(string uri)
			where TResponse : BaseResponse
		{
			var rest = new RestRequest(uri, Method.GET) { RequestFormat = DataFormat.Json };
			rest.AddHeader("MerchantKey", _merchantKey);
			rest.AddHeader("Accept", "application/json");

			Task<IRestResponse<TResponse>> task = _client.ExecuteGetTaskAsync<TResponse>(rest);

			task.Wait();

			return task.Result;
		}

	}
}