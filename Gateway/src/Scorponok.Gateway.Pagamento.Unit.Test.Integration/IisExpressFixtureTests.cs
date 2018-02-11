using Scorponok.Gateway.Pagamento.Unit.Test.Integration.FluentHttpclient;
using Scorponok.Shared.Contracts.Messages.Autorizar.Requests;
using Xunit;
using FluentAssertions;
using Scorponok.Shared.Contracts.Messages.Retentar.Requests;
using Scorponok.Shared.Contracts.Messages.Cancelar.Requests;
using Scorponok.Shared.Contracts.Messages.Capturar.Requests;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Integration
{
    public class IisExpressFixtureTests
    {
        [Theory]
        [InlineData("autorizar")]
        [InlineData("capturar")]
        [InlineData("cancelar")]
        [InlineData("retentar")]
        public async void Transacionar_transacao(string comando)
        {
            object request = null;

            if (comando == "autorizar") request = new AutorizaMessageRequest();
            if (comando == "capturar") request = new CapturaMessageRequest();
            if (comando == "cancelar") request = new CancelaMessageRequest();
            if (comando == "retentar") request = new RetentaMessageRequest();

            var response = await HttpRequestFactory.Post($"http://localhost:54228/api/Adquirente/{comando}/Transacao"
                , request);

            response.Should().NotBeNull();
            response.IsSuccessStatusCode.Should().Be(true);
            response.ReasonPhrase.Should().Be(System.Net.HttpStatusCode.OK.ToString());
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

    }
}
