using RestSharp;
using Scorponok.Gateway.Pagamento.Services.Cliente.Messages;
using Scorponok.Gateway.Pagamento.Services.Cliente.Stone;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Services.Cliente.Interfaces
{
    public interface IStoneServiceCliente
    {
        IRestResponse<CreateSaleMessageResponse> Autorizar(CreateSaleMessageRequest createSaleMessageRequest);
    }
}
