using FizzWare.NBuilder;
using Microsoft.Extensions.DependencyInjection;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas.IRespository;
using System;
using System.Collections.Generic;
using System.Text;
using Faker;
using Scorponok.Gateway.Pagamento.Cross.Cutting.Data.Repositorys;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Integration.Fakes
{
    public static class DomainFakes
    {
        private static readonly ServiceCollection services = new ServiceCollection();

        public static IServiceProvider ServiceProvider => services.BuildServiceProvider();

        static DomainFakes()
        {
            services.AddSingleton<ILojaRepository, LojaRepository>();
        }

        public static Loja GetLoja()
        {
            var repository = ServiceProvider.GetService<ILojaRepository>();

            BuilderSetup.SetCreatePersistenceMethod<Loja>(repository.Create);

            return Builder<Loja>
                .CreateNew()
                    .With(x => x.Id, Guid.NewGuid())
                    .With(x => x.Nome, Name.FullName())
                    .With(x => x.RazaoSocial, Name.FullName())
                    .With(x => x.Cnpj, Faker.Company.Suffix())
                .Persist();
        }
    }
}
