using AutoMapper;
using Scorponok.Gateway.Pagamento.Domain.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos;
using Scorponok.Shared.Contracts.Messages.Autorizar.Requests;

namespace Scorponok.Gateway.Pagamento.Transformations
{
    public class PedidoToAutorizaMessageRequest : Profile
    {
        public PedidoToAutorizaMessageRequest()
            => CreateMap<Pedido, AuthOnlyMessageRequest>();
    }
}
