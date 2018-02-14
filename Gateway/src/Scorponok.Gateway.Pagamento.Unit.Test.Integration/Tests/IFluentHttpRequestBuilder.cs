using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Integration.Tests
{
    public interface IFluentHttpRequestBuilder
    {
        IFluentHttpRequestBuilder SetEnvironment(Action<FluentSettings> configure);

        IFluentHttpRequestBuilder AddMethod(HttpMethod method);

        IFluentHttpRequestBuilder AddUri(string uri);

        IFluentHttpRequestBuilder AddUri(Uri uri);

        IFluentHttpRequestBuilder AddContent(HttpContent content);

        IFluentHttpRequestBuilder AddBearerToken(string bearerToken);

        IFluentHttpRequestBuilder AddAcceptHeader(string acceptHeader);

        IFluentHttpRequestBuilder WithTimeOut(int timeout = 500);

        IFluentHttpRequestBuilder WithTimeOut(TimeSpan timeout);

        IFluentHttpRequestBuilder AddAllowAutoRedirect(bool allowAutoRedirect);

        Task<HttpResponseMessage> SendAsync();
    }

}
