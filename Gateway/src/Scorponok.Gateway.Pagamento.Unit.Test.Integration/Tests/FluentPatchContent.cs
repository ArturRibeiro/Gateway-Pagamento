using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Integration.Tests
{
    public class FluentPatchContent : StringContent
    {
        public FluentPatchContent(object value)
            : base (JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json-patch+json")
        {
        }
    }
}
