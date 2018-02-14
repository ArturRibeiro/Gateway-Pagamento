using FluentAssertions;
using Scorponok.Shared.Contracts.Messages.Autorizar.Requests;
using Scorponok.Shared.Fluent.HttpClient;
using System.IO;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Integration.Tests
{
    public class Post
    {
        public int Id { get; set; }

        public int userId { get; set; }

        public string title { get; set; }

        public string body { get; set; }
    }

    public class FluentBuilderTests
    {
        [Theory]
        [InlineData("http://localhost:54228/api/Adquirente/autorizar/Transacao")]
        public async void Configura_variaveis_de_ambientes(string uri)
        {
            var builder = await HttpRequestBuilder
                .CreateNew(cfg =>
                    {
                        cfg.AddWebHostPath(@"C:\Users\scorponok\Source\github\Gateway-Pagamento\Adquirentes\src\Scorponok.Adquirente.Web.UI.Api");
                        cfg.AddEnvironment("ASPNETCORE_ENVIRONMENT", "Integration.Test");
                        cfg.AddEnvironment("REGISTRY_CONFIG_FILE", "appsettings.json");
                        cfg.AddEnvironment("REGISTRY_USE_DOCKER_SECRETS", "false");
                    })
                    .AddUri(uri: uri)
                    .AddMethod(HttpMethod.Post)
                    .AddContent(new JsonContent(new AutorizaMessageRequest()))
                    .SendAsync();

            //Assert's
            builder.Should().NotBeNull();
            builder.IsSuccessStatusCode.Should().Be(true);
            builder.ReasonPhrase.Should().Be(HttpStatusCode.OK.ToString());
            builder.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Theory]
        [InlineData("https://jsonplaceholder.typicode.com/posts/1")]
        public async void Get(string uri)
        {
            var builder = await HttpRequestBuilder
                .CreateNew()
                    .AddMethod(HttpMethod.Get)
                    .AddUri(uri: uri)
                .SendAsync();

            //Assert's
            builder.Should().NotBeNull();
            builder.IsSuccessStatusCode.Should().Be(true);
            builder.ReasonPhrase.Should().Be(HttpStatusCode.OK.ToString());
            builder.StatusCode.Should().Be(HttpStatusCode.OK);

            var response = builder.ContentAsType<Post>();
            response.Should().NotBeNull();
            response.Id.Should().Be(1);
            response.userId.Should().Be(1);
            response.title.Should().Contain("occaecati");
            response.body.Should().Contain("architecto");

        }

        [Theory]
        [InlineData("https://jsonplaceholder.typicode.com/posts/1")]
        public async void Put(string uri)
        {
            var builder = await HttpRequestBuilder
                .CreateNew()
                    .AddMethod(HttpMethod.Put)
                    .AddUri(uri: uri)
                .SendAsync();

            builder.Should().NotBeNull();
            builder.IsSuccessStatusCode.Should().Be(true);
            builder.ReasonPhrase.Should().Be(HttpStatusCode.OK.ToString());
            builder.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("https://jsonplaceholder.typicode.com/posts/1")]
        public async void Delete(string uri)
        {
            var builder = await HttpRequestBuilder
                .CreateNew()
                    .AddMethod(HttpMethod.Delete)
                    .AddUri(uri: uri)
                .SendAsync();

            builder.Should().NotBeNull();
            builder.IsSuccessStatusCode.Should().Be(true);
            builder.ReasonPhrase.Should().Be(HttpStatusCode.OK.ToString());
            builder.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("https://jsonplaceholder.typicode.com/posts")]
        public async void Post(string uri)
        {
            var builder = await HttpRequestBuilder
                .CreateNew()
                    .AddMethod(HttpMethod.Post)
                    .AddUri(uri: uri)
                .SendAsync();

            builder.Should().NotBeNull();
            builder.IsSuccessStatusCode.Should().Be(true);
            builder.ReasonPhrase.Should().Be(HttpStatusCode.Created.ToString());
            builder.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}
