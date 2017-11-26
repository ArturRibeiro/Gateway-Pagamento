using FizzWare.NBuilder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scorponok.Gateway.Pagamento.Data.Context;
using Scorponok.Gateway.Pagamento.Data.Repositorys;
using Scorponok.Gateway.Pagamento.Data.UoW;
using Scorponok.Gateway.Pagamento.Domain.Core.Bus;
using Scorponok.Gateway.Pagamento.Domain.Core.Events;
using Scorponok.Gateway.Pagamento.Domain.Core.Notifications;
using Scorponok.Gateway.Pagamento.Domain.Interfaces;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas.IRespository;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.CommandHandlers;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.CommandHandlers.Commands;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.EventHandlers;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.EventHandlers.Events;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.ICommandHandler;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IRespository;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IService;
using Scorponok.Gateway.Pagamento.Infra.Cross.Cutting.Bus;
using Scorponok.Gateway.Pagamento.Services;
using Scorponok.Gateway.Pagamento.Unit.Test.Integration.Fakes;
using System;
using System.Configuration;
using Xunit;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Integration.Commands
{
    public class PedidoCommandHandlerTests
    {
        [Theory]
        [InlineData("6C5CC434-6727-4EE6-9DA9-3043CA5BDB79", "AWDR35577", 1000, "012345678965")]
        public void PedidoCommand_sucesso(string lojaToken, string identificadorPedido, int valorEmCentavos, string numeroCartaoCredito)
        {

            var services = new ServiceCollection();

            this.RegistraTodos(services);

            var serviceProvider = services.BuildServiceProvider();

            InMemoryBus.ContainerAccessor = () => serviceProvider;

            var pedidoCommandHandler = serviceProvider.GetService<IPedidoCommandHandler>();

            var eventCommand = new AutorizarPedidoEventCommand(Guid.Parse(lojaToken), identificadorPedido, valorEmCentavos, numeroCartaoCredito, Faker.Name.FullName());

            pedidoCommandHandler.Handle(eventCommand);
        }

        private void RegistraTodos(ServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer("Data Source=DESKTOP-T5U2T7J;Initial Catalog=Gateway.Pagamento.Dev;Integrated Security=True"));
            RegistraRepositorys(services);
            RegistraCommandHandlers(services);
            RegistraDomainEvents(services);
            RegistraServices(services);
            RegistraBus(services);
        }

        private void RegistraDomainEvents(ServiceCollection services)
        {
            // Domain - Commands
            services.AddScoped<IPedidoCommandHandler, PedidoCommandHandler>();
            //services.AddScoped<IHandler<AutorizarPedidoEventCommand>, PedidoCommandHandler>();
            //services.AddScoped<IHandler<CancelarPedidoEventCommand>, PedidoCommandHandler>();
            //services.AddScoped<IHandler<CapturarPedidoEventCommand>, PedidoCommandHandler>();

            // Domain - Eventos
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<PedidoAutorizadoEvent>, PedidoEventHandler>();
            services.AddScoped<IHandler<PedidoCapturadaEvent>, PedidoEventHandler>();
            services.AddScoped<IHandler<PedidoCanceladoEvent>, PedidoEventHandler>();

        }

        private void RegistraBus(ServiceCollection services)
        {
            services.AddScoped<IBus, InMemoryBus>();
        }

        private void RegistraServices(ServiceCollection services)
        {
            services.AddScoped<IPedidoService, PedidoService>();
        }

        private void RegistraCommandHandlers(ServiceCollection services)
        {

        }

        private void RegistraRepositorys(ServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<ILojaRepository, LojaRepository>();
        }
    }
}
