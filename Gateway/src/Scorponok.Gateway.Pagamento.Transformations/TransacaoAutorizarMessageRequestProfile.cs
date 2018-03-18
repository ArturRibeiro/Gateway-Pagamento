using AutoMapper;
using Scorponok.Gateway.Pagamento.Domain.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes;
using Scorponok.Shared.Contracts.Messages.Autorizar.Requests;

namespace Scorponok.Gateway.Pagamento.Transformations
{
    public class TransacaoAutorizarMessageRequestProfile : Profile
    {
        public TransacaoAutorizarMessageRequestProfile()
        {
            //CreateMap<Transacao, TransactionAutorizarMessageRequest>()
            //    .ForMember();

            CreateMap<Transacao, TransactionMessageRequest>()
                .AfterMap((transacao, request, context) => {
                    //request.InstallmentCount = 0
                });
            //    .ForMember(dst => dst.Operacao, option => option.UseValue(Operacao.authorize))
            //    .ForMember(dst => dst.CreditCardTransaction, option => option.MapFrom(src => src))
            //    .ForMember(dst => dst.AfiliacaoToken, option => option.MapFrom(src => src.Afiliacao.Codigo))
            //    .ForMember(dst => dst.Adquirente, option => option.MapFrom(src => src.Transacao.Afiliacao.Adquirente.Nome))
            //    .ForMember(dst => dst.PedidoToken, option => option.MapFrom(src => src.First().Transacao.Pedido.Token))
            //    .ForMember(dst => dst.ShoppingCartCollection, option => option.MapFrom(src => src.Transacao.Pedido.Carrinho != null ? new[] { src.First().Transacao.Pedido.Carrinho } : new CarrinhoCompra[] { }))
            //    .ForMember(dst => dst.Buyer, option => option.MapFrom(src => src.Transacao.Pedido.Comprador))
            //    .ForMember(dst => dst.Options, option => option.MapFrom(src => src.Transacao.Pedido.Loja))
            //    .AfterMap((src, dst) => dst.MapearMerchantToken(src.Transacao.Pedido.Loja));
            ;
        }
    }
}
