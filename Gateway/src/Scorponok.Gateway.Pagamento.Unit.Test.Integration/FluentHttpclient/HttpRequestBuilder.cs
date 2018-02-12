using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Scorponok.Adquirente.Web.UI.Api;
using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Integration.FluentHttpclient
{
    public class HttpRequestBuilder
    {
        private HttpMethod method = null;
        private string requestUri = "";
        private HttpContent content = null;
        private string bearerToken = "";
        private string acceptHeader = "application/json";
        private TimeSpan timeout = new TimeSpan(0, 0, 15);
        private bool allowAutoRedirect = false;       

        public HttpRequestBuilder AddMethod(HttpMethod method)
        {
            this.method = method;
            return this;
        }

        public HttpRequestBuilder AddRequestUri(string requestUri)
        {
            this.requestUri = requestUri;
            return this;
        }

        public HttpRequestBuilder AddContent(HttpContent content)
        {
            this.content = content;
            return this;
        }

        public HttpRequestBuilder AddBearerToken(string bearerToken)
        {
            this.bearerToken = bearerToken;
            return this;
        }

        public HttpRequestBuilder AddAcceptHeader(string acceptHeader)
        {
            this.acceptHeader = acceptHeader;
            return this;
        }

        public HttpRequestBuilder AddTimeout(TimeSpan timeout)
        {
            this.timeout = timeout;
            return this;
        }

        public HttpRequestBuilder AddAllowAutoRedirect(bool allowAutoRedirect)
        {
            this.allowAutoRedirect = allowAutoRedirect;
            return this;
        }

        public async Task<HttpResponseMessage> SendAsync()
        {
            // Check required arguments
            EnsureArguments();

            // Set up request
            var request = new HttpRequestMessage
            {
                Method = this.method,
                RequestUri = new Uri(this.requestUri)
            };

            if (this.content != null)
                request.Content = this.content;

            if (!string.IsNullOrEmpty(this.bearerToken))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.bearerToken);

            request.Headers.Accept.Clear();
            if (!string.IsNullOrEmpty(this.acceptHeader))
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(this.acceptHeader));

            // Setup client
            //var handler = new HttpClientHandler();
            //handler.AllowAutoRedirect = this.allowAutoRedirect;
            //var client = new HttpClient(handler);

            //var host = new WebHostBuilder()
            //    .UseStartup<Startup>();
            //var _server = new TestServer(host);
            var client = ConfigurationEnvironment().CreateClient();
            client.Timeout = this.timeout;

            return await client.SendAsync(request);
        }

        #region " Private "

        private void EnsureArguments()
        {
            if (this.method == null)
                throw new ArgumentNullException("Method");

            if (string.IsNullOrEmpty(this.requestUri))
                throw new ArgumentNullException("Request Uri");
        }

        /// <summary>
        /// Referencias: 
        ///     https://jack-vanlightly.com/blog/2017/10/8/api-series-part-6-aspnet-core-20-and-integration-testing
        ///     http://asp.net-hacker.rocks/2017/09/27/testing-aspnetcore.html
        /// </summary>
        /// <returns></returns>
        private TestServer ConfigurationEnvironment()
        {
            // Devemos configurar o caminho real do projeto direcionado
            var appRootPath = @"C:\Users\scorponok\Source\github\Gateway-Pagamento\Adquirentes\src\Scorponok.Adquirente.Web.UI.Api";

            var environmentName = "Integration.Test";// ConfigurationManager.AppSettings["Environment.Scorponok.Adquirente.Web.UI.Api"];

            // define variáveis ​​de ambiente
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", environmentName);
            Environment.SetEnvironmentVariable("REGISTRY_CONFIG_FILE", Path.Combine(appRootPath, "appsettings.json"));
            //Environment.SetEnvironmentVariable("REGISTRY_DB_PASSWORD_SECRET_FILE", Path.Combine(appRootPath, "InsecureSecretFiles", "RegistryDbPassword.txt"));
            Environment.SetEnvironmentVariable("REGISTRY_USE_DOCKER_SECRETS", "false");

            return new TestServer(Program.GetWebHostBuilder(appRootPath, null));

        }
        #endregion
    }
}
