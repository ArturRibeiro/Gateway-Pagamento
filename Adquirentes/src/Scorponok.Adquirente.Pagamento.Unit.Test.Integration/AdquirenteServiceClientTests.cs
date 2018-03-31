using RestSharp;
using System;
using Xunit;
//using Scorponok.Gateway.Pagamento.Services.Cliente.Messages;
//using Scorponok.Gateway.Pagamento.Services.Cliente.Messages.EnumTypes;
using System.Collections.ObjectModel;
//using Scorponok.Gateway.Pagamento.Services.Cliente.Stone;
using FluentAssertions;
using System.Net;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using GatewayApiClient;
using Scorponok.Adquirente.Pagamento.Unit.Test.Integration;
using Scorponok.Adquirente.Pagamento.Unit.Test.Integration.EnumTypes;
using Scorponok.Shared.Fluent.HttpClient;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Integration.Services.Clients
{
	public class StoneAdquirenteServiceClientTests
	{
		private readonly RestClient _client;


		public StoneAdquirenteServiceClientTests() => _client = new RestClient("https://transaction.stone.com.br");


		#region Variables


		#endregion


		[Theory, InlineData("4111111111111111", CreditCardBrand.Visa, 10, 2018, "123", "LUKE SKYWALKER", HttpStatusCode.Created)]
		public void Transacao_criada_com_sucesso(string creditCardNumber, CreditCardBrand creditCardBrand, int expMonth, int expYear, string securityCode, string holderName, HttpStatusCode httpStatusCode)
		{
			//Arrange's
			var _createCreditCardSaleRequest = new CreateSaleRequest
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
			};

			var request = new RestRequest("/Sale", Method.POST) { RequestFormat = DataFormat.Json };
			request.AddHeader("MerchantKey", "f2a1f485-cfd4-49f5-8862-0ebc438ae923");
			request.AddBody(_createCreditCardSaleRequest);

			//Act's
			var rootObjectMessageResponse = _client.Execute<dynamic>(request);

			//Assert's
			rootObjectMessageResponse.StatusCode.Should().Be(httpStatusCode);
		}


		//[Theory]
		//[InlineData(HttpStatusCode.Unauthorized)]
		//public void Unauthorized(HttpStatusCode httpStatusCode)
		//{
		//	////Arrange's
		//	//var exemplo = new StoneRequestMessage()
		//	//{
		//	//	//Options = new Options()
		//	//	//{
		//	//	//	AntiFraudServiceCode = 0,
		//	//	//	IsAntiFraudEnabled = false,
		//	//	//	Retries = 0
		//	//	//},
		//	//	Buyer = new Buyer()
		//	//	{
		//	//		AddressCollection = new List<AddressCollection>()
		//	//		{
		//	//			new AddressCollection()
		//	//			{
		//	//				AddressType = "Residential",
		//	//				City = "Tatooine",
		//	//				Complement = "",
		//	//				Country = "Brazil",
		//	//				District = "Mos Eisley",
		//	//				Number = "123",
		//	//				State = "RJ",
		//	//				Street = "Mos Eisley Cantina",
		//	//				ZipCode = "20001000"
		//	//			}
		//	//		},
		//	//		Birthdate = $"{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}",
		//	//		BuyerReference = "C3PO",
		//	//		DocumentNumber = "12345678901",
		//	//		DocumentType = "CPF",
		//	//		Email = "lskywalker@r2d2.com",
		//	//		EmailType = "Personal",
		//	//		Gender = "M",
		//	//		HomePhone = "(21)123456789",
		//	//		MobilePhone = "(21)987654321",
		//	//		Name = "Luke Skywalker",
		//	//		PersonType = "Person",
		//	//		WorkPhone = "(21)28467902"
		//	//	},
		//	//	Transactions = new List<CreditCardTransactionCollection>()
		//	//	{
		//	//		new CreditCardTransactionCollection
		//	//		{
		//	//			//Options = new Options()
		//	//			//{
		//	//			//	CaptureDelayInMinutes = 0,
		//	//			//	CurrencyIso = "BRL",
		//	//			//	ExtendedLimitEnabled = false,
		//	//			//	IataAmountInCents = 0,
		//	//			//	PaymentMethodCode = 0
		//	//			//},
		//	//			CreditCardOperation = 1,
		//	//			AmountInCents = 900,
		//	//			CreditCard = new CreditCard()
		//	//			{
		//	//				CreditCardBrand = "1",
		//	//				CreditCardNumber = "4220612612415008",
		//	//				ExpMonth = 2,
		//	//				ExpYear = 2019,
		//	//				HolderName = "Marcio S Monteiro",
		//	//				SecurityCode = "660"
		//	//			},
		//	//			InstallmentCount = 1,
		//	//		}
		//	//	},
		//	//	Order = new Order()
		//	//	{
		//	//		OrderReference = Guid.NewGuid().ToString()
		//	//	}
		//	//};

		//	//var request = new RestRequest("/Sale", Method.POST);
		//	//request.RequestFormat = DataFormat.Json;
		//	//request.AddBody(exemplo);

		//	//var rootObjectMessageResponse = _client.Execute<dynamic>(request);

		//	//rootObjectMessageResponse.StatusCode.Should().Be(httpStatusCode);
		//}

		//[Theory, InlineData("MerchantKey", "7b379c45-57d6-4508-ae56-29bb0b3c9741", HttpStatusCode.OK)]
		//public void Authorized(string merchantKey, string token, HttpStatusCode httpStatusCode)
		//{

		//	CreateBuyerRequest _createBuyer = new CreateBuyerRequest
		//	{
		//		Birthdate = new DateTime(1994, 9, 26, 10, 35, 12),
		//		BuyerCategory = BuyerCategoryEnum.Normal,
		//		BuyerReference = "DotNet Buyer",
		//		CreateDateInMerchant = DateTime.UtcNow.AddDays(-5),
		//		DocumentNumber = "12345678901",
		//		DocumentType = DocumentTypeEnum.CPF,
		//		Email = "dotnet@developer.com",
		//		EmailType = EmailTypeEnum.Personal,
		//		FacebookId = "developer.net",
		//		Gender = GenderEnum.M,
		//		HomePhone = "2125247689",
		//		LastBuyerUpdateInMerchant = DateTime.UtcNow.AddDays(-2),
		//		MobilePhone = "21989685642",
		//		Name = "Dotnet Developer",
		//		PersonType = PersonTypeEnum.Person,
		//		TwitterId = "@developer.net",
		//		WorkPhone = "21965647826",
		//		AddressCollection = new Collection<BuyerAddress> { new BuyerAddress
		//		{
		//			AddressType = AddressTypeEnum.Residential,
		//			City = "Rio de Janeiro",
		//			Complement = "Aeroporto",
		//			Country = "Brazil",
		//			District = "Centro",
		//			Number = "123",
		//			State = "RJ",
		//			Street = "Av. General Justo",
		//			ZipCode = "20270230"
		//		}}
		//	};

		//	CreateSaleRequest _createCreditCardSaleRequest = new CreateSaleRequest
		//	{
		//		Buyer = _createBuyer,
		//		CreditCardTransactionCollection = new Collection<CreditCardTransaction>
		//		{
		//			new CreditCardTransaction
		//			{
		//				CreditCard = new CreditCard
		//				{
		//					CreditCardNumber = "4111111111111111",
		//					CreditCardBrand = CreditCardBrandEnum.Visa,
		//					ExpMonth = 10,
		//					ExpYear = 2018,
		//					SecurityCode = "123",
		//					HolderName = "LUKE SKYWALKER"
		//				},
		//				AmountInCents = 100,
		//				Options = new CreditCardTransactionOptions{PaymentMethodCode = 1}
		//			}
		//		}
		//	};



		//	var request = new RestRequest("/Sale", Method.POST);
		//	request.RequestFormat = DataFormat.Json;
		//	request.AddHeader(merchantKey, token);
		//	request.AddBody(_createCreditCardSaleRequest);

		//	var rootObjectMessageResponse = _client.Execute<dynamic>(request);

		//	rootObjectMessageResponse.StatusCode.Should().Be(httpStatusCode);
		//}

		//public void Authorized(string merchantKey, string token)
		//{
		//	//Arrange's
		//	var exemplo = new Example()
		//	{
		//		//Options = new Options()
		//		//{
		//		//	AntiFraudServiceCode = 0,
		//		//	IsAntiFraudEnabled = false,
		//		//	Retries = 0
		//		//},
		//		Transactions = new List<CreditCardTransactionCollection>()
		//		{
		//			new CreditCardTransactionCollection
		//			{
		//				Options = new Options()
		//				{
		//					CaptureDelayInMinutes = 0,
		//					CurrencyIso = "BRL",
		//					ExtendedLimitEnabled = false,
		//					IataAmountInCents = 0,
		//					PaymentMethodCode = 0
		//				},
		//				CreditCardOperation = 1,
		//				AmountInCents = 900,
		//				CreditCard = new CreditCard()
		//				{
		//					CreditCardBrand = "1",
		//					CreditCardNumber = "4220612612415008",
		//					ExpMonth = 2,
		//					ExpYear = 2019,
		//					HolderName = "Marcio S Monteiro",
		//					SecurityCode = "660"
		//				},
		//				InstallmentCount = 1,
		//			}
		//		},
		//		Order = new Order()
		//		{
		//			OrderReference = "0123456789"
		//		}
		//	};

		//	;
		//	//// Cria requisição.
		//	//var createSaleRequest = new CreateSaleMessageRequest()
		//	//{
		//	//    // Adiciona a transação na requisição.
		//	//    CreditCardTransactionCollection = new Collection<CreditCardTransaction>(transacoes),
		//	//    Order = new Order() { OrderReference = Guid.NewGuid().ToString() }
		//	//};

		//	//createSaleRequest.AddToken(merchantKey, token);

		//	//createSaleRequest.Options.AntiFraudServiceCode = 0;
		//	//createSaleRequest.Options.IsAntiFraudEnabled = false;
		//	//createSaleRequest.Options.Retries = 0;

		//	//Act's
		//	//var builder = HttpRequestBuilder
		//	//	.CreateNew()
		//	//	.AddMethod(HttpMethod.Post)
		//	//	.AddUri("https://transaction.stone.com.br/Sale")
		//	//	//.AddContent(new JsonContent(exemplo))
		//	//	//.AddHeader("MerchantKey", "f2a1f485-cfd4-49f5-8862-0ebc438ae923")
		//	//	//.AddHeader("Content-Type", "application/json")
		//	//	//.AddHeader("Accept", "application/json")
		//	//	.SendAsync();

		//	//builder.Wait();

		//	HttpClient client = new HttpClient();

		//	var response = client.PostAsync("https://transaction.stone.com.br/Sale", new JsonContent(exemplo));
		//	client.DefaultRequestHeaders.Add("MerchantKey", "f2a1f485-cfd4-49f5-8862-0ebc438ae923");
		//	//client.DefaultRequestHeaders.Add("Content-Type", "application/json");
		//	//client.DefaultRequestHeaders.Add("Accept", "application/json");
		//	response.Wait();
		//	response.Result.EnsureSuccessStatusCode();

		//	// return URI of the created resource.
		//	//var result = response.Headers.Location;

		//	//var service = new StoneServiceCliente();
		//	//var createSaleMessageResponse = service.Autorizar(createSaleRequest);

		//	////Assert's
		//	//createSaleMessageResponse.IsSuccessful.Should().Be(true);
		//	//createSaleMessageResponse.StatusCode.Should().Be(HttpStatusCode.Created);
		//}
	}
}
