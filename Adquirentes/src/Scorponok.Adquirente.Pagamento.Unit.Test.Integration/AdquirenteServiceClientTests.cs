using RestSharp;
using System;
using Xunit;
using Scorponok.Gateway.Pagamento.Services.Cliente.Messages;
using Scorponok.Gateway.Pagamento.Services.Cliente.Messages.EnumTypes;
using System.Collections.ObjectModel;
using Scorponok.Gateway.Pagamento.Services.Cliente.Stone;
using FluentAssertions;
using System.Net;
using System.Collections.Generic;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Integration.Services.Clients
{
    #region Request

    #endregion



    public class StoneAdquirenteServiceClientTests
    {
        private readonly RestClient _client;

        public StoneAdquirenteServiceClientTests()
        {
            _client = new RestClient("https://transaction.stone.com.br");
        }

        //[Theory]
        //[InlineData(HttpStatusCode.Unauthorized)]
        //public void Unauthorized(HttpStatusCode httpStatusCode)
        //{
        //    var request = new RestRequest("/Sale", Method.POST);
        //    request.RequestFormat = DataFormat.Json;
        //    request.AddBody(new StonePreAutorizacaoMessageRequest());

        //    var rootObjectMessageResponse = _client.Execute<RootObject>(request);

        //    rootObjectMessageResponse.StatusCode.Should().Be(httpStatusCode);
        //}

        public IList<CreditCardTransaction> CriandoTransacaoBasicaStone()
        {
            // Cria a transação.
            var transaction = new CreditCardTransaction()
            {
                AmountInCents = 10000,
                CreditCard = new CreditCard()
                {
                    CreditCardBrand = CreditCardBrandEnum.Visa,
                    CreditCardNumber = "4111111111111111",
                    ExpMonth = 10,
                    ExpYear = 22,
                    HolderName = "LUKE SKYWALKER",
                    SecurityCode = "123"
                },
                InstallmentCount = 1
            };

            var transaction2 = new CreditCardTransaction()
            {
                Options = new CreditCardTransactionOptions() { PaymentMethodCode = 1 },
                AmountInCents = 10000,
                CreditCard = new CreditCard()
                {
                    CreditCardBrand = CreditCardBrandEnum.Visa,
                    CreditCardNumber = "4111111111111112",
                    ExpMonth = 10,
                    ExpYear = 22,
                    HolderName = "LUKE SKYWALKER",
                    SecurityCode = "123"
                },
                CreditCardOperation = CreditCardOperationEnum.AuthOnly,
                InstallmentCount = 1
            };

            return new[] { transaction, transaction2 };
        }

        [Theory]
        [InlineData("MerchantKey", "7b379c45-57d6-4508-ae56-29bb0b3c9741")]
        public void Authorized(string merchantKey, string token)
        {

            //Arrange's            
            var transacoes = CriandoTransacaoBasicaStone();

            // Cria requisição.
            var createSaleRequest = new CreateSaleMessageRequest()
            {
                // Adiciona a transação na requisição.
                CreditCardTransactionCollection = new Collection<CreditCardTransaction>(transacoes),
                Order = new Order() { OrderReference = Guid.NewGuid().ToString() }
            };

            createSaleRequest.AddToken(merchantKey, token);

            createSaleRequest.Options.AntiFraudServiceCode = 0;
            createSaleRequest.Options.IsAntiFraudEnabled = false;
            createSaleRequest.Options.Retries = 0;

            //Act's
            var service = new StoneServiceCliente();
            var createSaleMessageResponse = service.Autorizar(createSaleRequest);

            //Assert's
            createSaleMessageResponse.IsSuccessful.Should().Be(true);
            createSaleMessageResponse.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}
