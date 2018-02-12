using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Integration.Tests
{
    public interface IHttpRequestBuilder
    {
        IHttpRequestBuilder SetEnvironment();

        IHttpRequestBuilder AddMethod(HttpMethod method);

        IHttpRequestBuilder AddUri(string uri);

        IHttpRequestBuilder AddUri(Uri uri);

        IHttpRequestBuilder AddContent(HttpContent content);

        IHttpRequestBuilder AddBearerToken(string bearerToken);

        IHttpRequestBuilder AddAcceptHeader(string acceptHeader);

        IHttpRequestBuilder WithTimeOut(int timeout = 500);

        IHttpRequestBuilder WithTimeOut(TimeSpan timeout);

        IHttpRequestBuilder AddAllowAutoRedirect(bool allowAutoRedirect);

        Task<HttpResponseMessage> SendAsync();
    }

}
