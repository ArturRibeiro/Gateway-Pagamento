using System.IO;
using System.Net.Http;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Integration.Tests
{
    public class FluentFileContent : MultipartFormDataContent
    {
        public FluentFileContent(string filePath, string apiParamName)
        {
            var filestream = File.Open(filePath, FileMode.Open);
            var filename = Path.GetFileName(filePath);

            Add(new StreamContent(filestream), apiParamName, filename);
        }
    }
}
