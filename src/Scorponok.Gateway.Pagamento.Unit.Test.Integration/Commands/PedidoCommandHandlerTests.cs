using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scorponok.Gateway.Pagamento.Data.Context;
using Scorponok.Gateway.Pagamento.Data.Repositorys;
using Scorponok.Gateway.Pagamento.Data.UoW;
using Scorponok.Gateway.Pagamento.Domain.Core.Bus;
using Scorponok.Gateway.Pagamento.Domain.Core.Events;
using Scorponok.Gateway.Pagamento.Domain.Core.Notifications;
using Scorponok.Gateway.Pagamento.Domain.Interfaces;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.CommandHandlers;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.CommandHandlers.Commands;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IRespository;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IService;
using Scorponok.Gateway.Pagamento.Infra.Cross.Cutting.Bus;
using Scorponok.Gateway.Pagamento.Services;
using System;
using System.Configuration;
using Xunit;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Integration.Commands
{
    public class PedidoCommandHandlerTests
    {
        [Fact]
        public void PedidoCommand_sucesso()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;

            var services = new ServiceCollection();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
            
            RegistraRepositorys(services);
            RegistraCommandHandlers(services);
            RegistraDomainEvents(services);
            RegistraServices(services);
            RegistraBus(services);

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            PedidoCommandHandler commandHandler = serviceProvider.GetService<PedidoCommandHandler>();
        }

        private void RegistraDomainEvents(ServiceCollection services)
        {
            // Domain - Eventos
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            //services.AddScoped<IHandler<EventoRegistradoEvent>, EventoEventHandler>();
            //services.AddScoped<IHandler<EventoAtualizadoEvent>, EventoEventHandler>();
            //services.AddScoped<IHandler<EventoExcluidoEvent>, EventoEventHandler>();
            //services.AddScoped<IHandler<EnderecoEventoAtualizadoEvent>, EventoEventHandler>();
            //services.AddScoped<IHandler<EnderecoEventoAdicionadoEvent>, EventoEventHandler>();
            //services.AddScoped<IHandler<OrganizadorRegistradoEvent>, OrganizadorEventHandler>();
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
            services.AddScoped<IHandler<AutorizarPedidoEventCommand>, PedidoCommandHandler>();
            services.AddScoped<IHandler<CancelarPedidoEventCommand>, PedidoCommandHandler>();
            services.AddScoped<IHandler<CapturarPedidoEventCommand>, PedidoCommandHandler>();
        }

        private void RegistraRepositorys(ServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
        }
    }
}
