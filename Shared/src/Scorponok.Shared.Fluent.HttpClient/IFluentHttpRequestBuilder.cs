using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Scorponok.Shared.Fluent.HttpClient
{
    public interface IFluentHttpRequestBuilder
    {
        IFluentHttpRequestBuilder SetEnvironment(Action<Settings> configure);

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
