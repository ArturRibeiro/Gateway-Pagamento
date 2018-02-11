using Scorponok.Gateway.Pagamento.Services.Cliente.Interfaces;
using Scorponok.Gateway.Pagamento.Services.Cliente.Messages;
using RestSharp;
using System;

namespace Scorponok.Gateway.Pagamento.Services.Cliente.Stone
{
    public class StoneServiceCliente : IStoneServiceCliente
    {
        private readonly RestClient _client;

        public StoneServiceCliente()
        {
            _client = new RestClient("https://transaction.stone.com.br");
        }

        public void AddHeader(Action action)
        {

        }

        public IRestResponse<CreateSaleMessageResponse> Autorizar(CreateSaleMessageRequest createSaleMessageRequest)
        {
            var request = new RestRequest("/Sale", Method.POST);
            //request.AddHeader("MerchantKey", "7b379c45-57d6-4508-ae56-29bb0b3c9741");

            foreach (var item in createSaleMessageRequest.Headers)
                request.AddHeader(item.Key, item.Value.ToString());
            

            request.RequestFormat = DataFormat.Json;
            request.AddBody(createSaleMessageRequest);

            var result = _client.Execute<CreateSaleMessageResponse>(request);

            return result;
        }
    }
}
