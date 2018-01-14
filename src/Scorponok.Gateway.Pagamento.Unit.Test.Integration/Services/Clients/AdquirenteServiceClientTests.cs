using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using Xunit;
using FluentAssertions;
using Scorponok.Gateway.Pagamento.Services.Cliente.Messages;
using Scorponok.Gateway.Pagamento.Services.Cliente.Messages.EnumTypes;
using System.Collections.ObjectModel;
using Scorponok.Gateway.Pagamento.Services.Cliente.Stone;


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

        [Theory]
        [InlineData(HttpStatusCode.Created)]
        public void Authorized(HttpStatusCode httpStatusCode)
        {

            //Arrange's            
            var transaction1 = new CreditCardTransaction()
            {
                Options = new CreditCardTransactionOptions() { PaymentMethodCode = 1 },
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
                CreditCardOperation = CreditCardOperationEnum.AuthOnly,
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

            // Cria requisição.
            var createSaleRequest = new CreateSaleRequest()
            {
                // Adiciona a transação na requisição.
                CreditCardTransactionCollection = new Collection<CreditCardTransaction>(new CreditCardTransaction[] { transaction1, transaction2 }),
                Order = new Order() { OrderReference = Guid.NewGuid().ToString() }
            };
            createSaleRequest.Options.AntiFraudServiceCode = 0;
            createSaleRequest.Options.IsAntiFraudEnabled = false;
            createSaleRequest.Options.Retries = 0;

            var service = new StoneServiceCliente();

            var createSaleMessageResponse = service.Autorizar(createSaleRequest);
            

            //createSaleMessageResponse.StatusCode.Should().Be(httpStatusCode);
        }



    }
}
