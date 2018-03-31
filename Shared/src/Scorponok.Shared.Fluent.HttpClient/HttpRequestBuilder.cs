using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Scorponok.Shared.Fluent.HttpClient
{
    public sealed class HttpRequestBuilder : IFluentHttpRequestBuilder
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
        private Action<Settings> _environmentVariables;
        #endregion

        #region Construtor
        public HttpRequestBuilder(HttpRequestMessage httpRequestMessage)
            => _httpRequestMessage = httpRequestMessage;

        public HttpRequestBuilder(HttpRequestMessage httpRequestMessage, Action<Settings> configure)
            : this(httpRequestMessage)
            => _environmentVariables = configure;
        #endregion

        #region Métodos Publicos

        public IFluentHttpRequestBuilder SetEnvironment(Action<Settings> configure)
        {
            _environmentVariables = configure;

            return this;
        }

	    public IFluentHttpRequestBuilder AddHeader(string name, string value)
	    {
			_httpRequestMessage.Headers.Add(name, value);

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

            System.Net.Http.HttpClient client;

            if (server == null)
            {
                var handler = new HttpClientHandler { AllowAutoRedirect = _allowAutoRedirect };
                client = new System.Net.Http.HttpClient(handler) { Timeout = _timeout };
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
            => new HttpRequestBuilder(new HttpRequestMessage());

        public static IFluentHttpRequestBuilder CreateNew(Action<Settings> configure)
            => new HttpRequestBuilder(new HttpRequestMessage(), configure);

        #endregion

        #region Métodos Privados
        private static Settings BuildEnvironment(Action<Settings> configure)
        {
            var expr = new Settings();
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

                //TODO: Refactor
                return new TestServer(Adquirente.Web.UI.Api.Program.GetWebHostBuilder(settings.PathWebHost, null));
            }

            return null;
        }

        private void CreateEnvironmentVariable(string variable, string value)
            => System.Environment.SetEnvironmentVariable(variable, value);
        #endregion
    }

}
