using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scorponok.Gateway.Pagamento.Cross.Cutting.Data.Context;
using Scorponok.Gateway.Pagamento.Cross.Cutting.Data.Repositorys;
using Scorponok.Gateway.Pagamento.Cross.Cutting.Data.UoW;
using Scorponok.Gateway.Pagamento.Domain.Core.Bus;
using Scorponok.Gateway.Pagamento.Domain.Core.Events;
using Scorponok.Gateway.Pagamento.Domain.Core.Notifications;
using Scorponok.Gateway.Pagamento.Domain.Interfaces;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas.IRespository;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.CommandHandlers;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.EventHandlers;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.EventHandlers.Events;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.ICommandHandler;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IRespository;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IService;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes.CommandHandlers;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes.ICommandHandler;
using Scorponok.Gateway.Pagamento.Infra.Cross.Cutting.Bus;
using Scorponok.Gateway.Pagamento.Services.Entity;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Integration.Commands
{
    public class BaseIntegrationTest
    {

        private readonly ServiceCollection _services;
        protected readonly ServiceProvider _serviceProvider;

        public BaseIntegrationTest()
        {
            _services = new ServiceCollection();
            RegistraTodos();

            _serviceProvider = _services.BuildServiceProvider();
            InMemoryBus.ContainerAccessor = () => _serviceProvider;
        }

        private void RegistraTodos()
        {
            _services.AddDbContext<DataContext>(options => options.UseSqlServer("Data Source=DESKTOP-T5U2T7J;Initial Catalog=Gateway.Pagamento.Dev;Integrated Security=True"));
            RegistraRepositorys();
            RegistraCommandHandlers();
            RegistraDomainEvents();
            RegistraServices();
            RegistraBus();
        }

        private void RegistraDomainEvents()
        {
            // Domain - Commands
            _services.AddScoped<IPedidoCommandHandler, PedidoCommandHandler>();
            _services.AddScoped<ITransacaoCommandHandler, TransacaoCommandHandler>();
            //services.AddScoped<IHandler<AutorizarPedidoEventCommand>, PedidoCommandHandler>();
            //services.AddScoped<IHandler<CancelarPedidoEventCommand>, PedidoCommandHandler>();
            //services.AddScoped<IHandler<CapturarPedidoEventCommand>, PedidoCommandHandler>();

            // Domain - Eventos
            _services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            _services.AddScoped<IHandler<PedidoAutorizadoEvent>, PedidoEventHandler>();
            _services.AddScoped<IHandler<PedidoCapturadaEvent>, PedidoEventHandler>();
            _services.AddScoped<IHandler<PedidoCanceladoEvent>, PedidoEventHandler>();

        }

        private void RegistraBus()
        {
            _services.AddScoped<IBus, InMemoryBus>();
        }

        private void RegistraServices()
        {
            _services.AddScoped<IPedidoService, PedidoService>();
        }

        private void RegistraCommandHandlers()
        {

        }

        private void RegistraRepositorys()
        {
            _services.AddScoped<IUnitOfWork, UnitOfWork>();
            _services.AddScoped<IPedidoRepository, PedidoRepository>();
            _services.AddTransient<ILojaRepository, LojaRepository>();
            //_services.AddTransient<IOperationTransient, Operation>();
        }
    }
}