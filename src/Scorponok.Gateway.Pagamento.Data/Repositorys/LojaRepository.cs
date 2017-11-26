using Scorponok.Gateway.Pagamento.Domain.Models.Lojas;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas.IRespository;
using System;
using System.Collections.Generic;
using System.Text;
using Scorponok.Gateway.Pagamento.Data.Context;

namespace Scorponok.Gateway.Pagamento.Data.Repositorys
{
    public class LojaRepository : RepositoryBase<Loja>, ILojaRepository
    {
        public LojaRepository(DataContext context) : base(context)
        {
        }
    }
}
