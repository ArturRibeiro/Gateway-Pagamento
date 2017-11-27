using Scorponok.Gateway.Pagamento.Cross.Cutting.Data.Context;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas.IRespository;

namespace Scorponok.Gateway.Pagamento.Cross.Cutting.Data.Repositorys
{
    public class LojaRepository : RepositoryBase<Loja>, ILojaRepository
    {
        public LojaRepository(DataContext context) : base(context)
        {
        }
    }
}
