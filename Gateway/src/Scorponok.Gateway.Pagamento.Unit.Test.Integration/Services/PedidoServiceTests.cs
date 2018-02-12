using FluentAssertions;
using Scorponok.Gateway.Pagamento.Unit.Test.Integration.FluentHttpclient;
using Scorponok.Shared.Contracts.Messages.Autorizar.Requests;
using Scorponok.Shared.Contracts.Messages.Cancelar.Requests;
using Scorponok.Shared.Contracts.Messages.Capturar.Requests;
using Scorponok.Shared.Contracts.Messages.Retentar.Requests;
using System.Net;
using Xunit;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Integration.Services
{
    public class PedidoServiceTests
    {
        [Fact]
        public async void Autorizar_transacao()
        {
            var response = await HttpRequestFactory.Post($"http://localhost:54228/api/Adquirente/autorizar/Transacao"
                , new AutorizaMessageRequest());

            response.Should().NotBeNull();
            response.IsSuccessStatusCode.Should().Be(true);
            response.ReasonPhrase.Should().Be(HttpStatusCode.OK.ToString());
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async void Capturar_transacao()
        {
            var response = await HttpRequestFactory.Post($"http://localhost:54228/api/Adquirente/capturar/Transacao"
                , new CapturaMessageRequest());

            response.Should().NotBeNull();
            response.IsSuccessStatusCode.Should().Be(true);
            response.ReasonPhrase.Should().Be(HttpStatusCode.OK.ToString());
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async void Cancelar_transacao()
        {
            var response = await HttpRequestFactory.Post($"http://localhost:54228/api/Adquirente/cancelar/Transacao"
                , new CancelaMessageRequest());

            response.Should().NotBeNull();
            response.IsSuccessStatusCode.Should().Be(true);
            response.ReasonPhrase.Should().Be(HttpStatusCode.OK.ToString());
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async void Retentar_transacao()
        {
            var response = await HttpRequestFactory.Post($"http://localhost:54228/api/Adquirente/retentar/Transacao"
                , new RetentaMessageRequest());

            response.Should().NotBeNull();
            response.IsSuccessStatusCode.Should().Be(true);
            response.ReasonPhrase.Should().Be(HttpStatusCode.OK.ToString());
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
