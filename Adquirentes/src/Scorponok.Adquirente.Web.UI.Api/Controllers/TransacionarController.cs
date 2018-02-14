using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scorponok.Shared.Contracts.Messages.Autorizar.Requests;
using Scorponok.Shared.Contracts.Messages.Cancelar.Requests;
using Scorponok.Shared.Contracts.Messages.Capturar.Requests;
using Scorponok.Shared.Contracts.Messages.Retentar.Requests;

namespace Scorponok.Adquirente.Web.UI.Api.Controllers
{
    //[Produces("application/json")]
    [Route("api/Adquirente")]
    public class TransacionarController : Controller
    {

        [HttpPost, Route("autorizar/Transacao")]
        public async Task<HttpResponseMessage> Autorizar([FromBody] AutorizaMessageRequest request)
            => AutorizarTransacao(request);

        [HttpPost, Route("capturar/Transacao")]
        public async Task<HttpResponseMessage> Capturar([FromBody] CapturaMessageRequest request)
            => CapturarTransacao(request);

        [HttpPost, Route("cancelar/Transacao")]
        public async Task<HttpResponseMessage> Cancelar([FromBody] CancelaMessageRequest request)
            => CancelaTransacao(request);

        [HttpPost, Route("retentar/Transacao")]
        public async Task<HttpResponseMessage> Retentar([FromBody] RetentaMessageRequest request)
            => RetentarTransacao(request);

        #region Métodos Privados

        private HttpResponseMessage AutorizarTransacao(AutorizaMessageRequest request)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            //response.Content = new HttpContent();
            return response;
        }

        private HttpResponseMessage CapturarTransacao(CapturaMessageRequest request)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            //response.Content = new HttpContent();
            return response;
        }

        private HttpResponseMessage CancelaTransacao(CancelaMessageRequest request)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            //response.Content = new HttpContent();
            return response;
        }

        private HttpResponseMessage RetentarTransacao(RetentaMessageRequest request)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            //response.Content = new HttpContent();
            return response;
        }
        #endregion
    }
}
