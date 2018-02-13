using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Integration.Tests
{
    public sealed class FluentHttpRequestBuilder : IFluentHttpRequestBuilder
    {
        #region Atributos
        private HttpRequestMessage _httpRequestMessage;
        private HttpMethod _method;
        private Uri _uri;
        private HttpContent _content;
        private TimeSpan _timeout = new TimeSpan(0, 0, 15);
        private string _bearerToken;
        private string _acceptHeader = "application/json";
        private bool _allowAutoRedirect = false;
        private Action<AppSettings> _environmentVariables;
        #endregion

        #region Construtor
        public FluentHttpRequestBuilder(HttpRequestMessage httpRequestMessage)
            => _httpRequestMessage = httpRequestMessage;

        public FluentHttpRequestBuilder(HttpRequestMessage httpRequestMessage, Action<AppSettings> configure)
            : this(httpRequestMessage)
            => _environmentVariables = configure;
        #endregion

        #region Métodos Publicos

        public IFluentHttpRequestBuilder SetEnvironment(Action<AppSettings> configure)
        {
            _environmentVariables = configure;

            return this;
        }

        public IFluentHttpRequestBuilder AddAcceptHeader(string acceptHeader)
        {
            if (!string.IsNullOrEmpty(_acceptHeader)) _httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(acceptHeader));

            return this;
        }

        public IFluentHttpRequestBuilder AddAllowAutoRedirect(bool allowAutoRedirect)
        {
            _allowAutoRedirect = allowAutoRedirect;
            return this;
        }

        public IFluentHttpRequestBuilder AddBearerToken(string bearerToken)
        {
            _httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            return this;
        }

        public IFluentHttpRequestBuilder AddContent(HttpContent content)
        {
            _httpRequestMessage.Content = content;
            return this;
        }

        public IFluentHttpRequestBuilder AddMethod(HttpMethod method)
        {
            _httpRequestMessage.Method = method;
            return this;
        }

        public IFluentHttpRequestBuilder WithTimeOut(int timeout = 500)
        {
            _timeout = new TimeSpan(timeout);

            return this;
        }

        public IFluentHttpRequestBuilder WithTimeOut(TimeSpan timeout)
        {
            _timeout = timeout;
            return this;
        }

        public IFluentHttpRequestBuilder AddUri(string uri)
        {
            _httpRequestMessage.RequestUri = new Uri(uri);
            return this;
        }

        public IFluentHttpRequestBuilder AddUri(Uri uri)
        {
            _httpRequestMessage.RequestUri = uri;

            return this;
        }

        public async Task<HttpResponseMessage> SendAsync()
        {
            var server = CreatesAllEnvironmentVariables();

            HttpClient client;

            if (server == null)
            {
                var handler = new HttpClientHandler { AllowAutoRedirect = _allowAutoRedirect };
                client = new HttpClient(handler) { Timeout = _timeout };
            }
            else
            {
                client = server.CreateClient();
                client.Timeout = _timeout;
            }
            ;
            var response = await client.SendAsync(_httpRequestMessage);

            return response;
        }
        
        public static IFluentHttpRequestBuilder CreateNew()
            => new FluentHttpRequestBuilder(new HttpRequestMessage());

        public static IFluentHttpRequestBuilder CreateNew(Action<AppSettings> configure)
            => new FluentHttpRequestBuilder(new HttpRequestMessage(), configure);

        #endregion

        #region Métodos Privados
        private static AppSettings BuildEnvironment(Action<AppSettings> configure)
        {
            var expr = new AppSettings();
            configure(expr);
            return expr;
        }

        private TestServer CreatesAllEnvironmentVariables()
        {
            if (_environmentVariables == null) return null;

            var settings = BuildEnvironment(_environmentVariables);

            if (settings.Variables.Count > 0)
            {
                foreach (var item in settings.Variables) CreateEnvironmentVariable(item.Key, item.Value);

                return new TestServer(Adquirente.Web.UI.Api.Program.GetWebHostBuilder(settings.PathWebHost, null));
            }

            return null;
        }

        private void CreateEnvironmentVariable(string variable, string value)
            => System.Environment.SetEnvironmentVariable(variable, value);
        #endregion
    }

}
