using AutoMapper;
using Scorponok.Gateway.Pagamento.Domain.Models;
using Scorponok.Shared.Contracts.Messages.Autorizar.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Transformations
{
    public class PedidoAutorizarMessageRequestProfile : Profile
    {
        public PedidoAutorizarMessageRequestProfile()
        {
            CreateMap<Pedido, OrderMessageRequest>()
                .ForMember(dst => dst.OrderReference, option => option.MapFrom(src => src.IdentificadorPedido));
        }
    }
}
