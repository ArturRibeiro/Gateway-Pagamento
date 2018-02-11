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
    [Produces("application/json")]
    [Route("api/Adquirente")]
    public class TransacionarController : Controller
    {
        [HttpPost, Route("autorizar/Transacao")]
        public async Task<HttpResponseMessage> Autorizar([FromBody] AutorizaMessageRequest request)
            => await AutorizarTransacao(request);

        [HttpPost(Name = "capturar")]
        public async Task<HttpResponseMessage> Capturar([FromBody] CapturaMessageRequest request)
            => await CapturarTransacao(request);

        [HttpPost, Route("cancelar/Transacao")]
        public async Task<HttpResponseMessage> Cancelar([FromBody] CancelaMessageRequest request)
            => await CancelaTransacao(request);

        [HttpPost, Route("retentar/Transacao")]
        public async Task<HttpResponseMessage> Retentar([FromBody] RetentaMessageRequest request)
            => await RetentarTransacao(request);

        #region Métodos Privados

        private async Task<HttpResponseMessage> AutorizarTransacao(AutorizaMessageRequest request)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        private async Task<HttpResponseMessage> CapturarTransacao(CapturaMessageRequest request)
        {
            throw new NotImplementedException();
        }

        private async Task<HttpResponseMessage> CancelaTransacao(CancelaMessageRequest request)
        {
            throw new NotImplementedException();
        }

        private async Task<HttpResponseMessage> RetentarTransacao(RetentaMessageRequest request)
        {
            throw new NotImplementedException();
        }
        #endregion

        //// GET: api/Transacionar
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Transacionar/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return $"value: {id}";
        //}

        //// POST: api/Transacionar
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Transacionar/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
