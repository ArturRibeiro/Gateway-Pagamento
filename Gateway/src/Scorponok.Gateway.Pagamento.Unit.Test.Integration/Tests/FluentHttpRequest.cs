using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Integration.Tests
{
    public sealed class FluentHttpRequest : IHttpRequestBuilder
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
        #endregion

        public FluentHttpRequest(HttpRequestMessage httpRequestMessage)
        {
            _httpRequestMessage = httpRequestMessage;
        }

        public IHttpRequestBuilder SetEnvironment()
        {
            return this;
        }

        #region Métodos Publicos
        public IHttpRequestBuilder AddAcceptHeader(string acceptHeader)
        {
            if (!string.IsNullOrEmpty(_acceptHeader)) _httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(acceptHeader));

            return this;
        }

        public IHttpRequestBuilder AddAllowAutoRedirect(bool allowAutoRedirect)
        {
            _allowAutoRedirect = allowAutoRedirect;
            return this;
        }

        public IHttpRequestBuilder AddBearerToken(string bearerToken)
        {
            _httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            return this;
        }

        public IHttpRequestBuilder AddContent(HttpContent content)
        {
            _httpRequestMessage.Content = content;
            return this;
        }

        public IHttpRequestBuilder AddMethod(HttpMethod method)
        {
            _httpRequestMessage.Method = method;
            return this;
        }

        public IHttpRequestBuilder WithTimeOut(int timeout = 500)
        {
            _timeout = new TimeSpan(timeout);

            return this;
        }

        public IHttpRequestBuilder WithTimeOut(TimeSpan timeout)
        {
            _timeout = timeout;
            return this;
        }

        public IHttpRequestBuilder AddUri(string uri)
        {
            _httpRequestMessage.RequestUri = new Uri(uri);
            return this;
        }

        public IHttpRequestBuilder AddUri(Uri uri)
        {
            _httpRequestMessage.RequestUri = uri;

            return this;
        }

        public async Task<HttpResponseMessage> SendAsync()
        {
            var handler = new HttpClientHandler { AllowAutoRedirect = _allowAutoRedirect };
            var client = new HttpClient(handler) { Timeout = _timeout };
            var response = await client.SendAsync(_httpRequestMessage);

            return response;
        }
        #endregion

        public static IHttpRequestBuilder CreateNew()
            => new FluentHttpRequest(new HttpRequestMessage());
    }

}
