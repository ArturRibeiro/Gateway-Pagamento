using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Scorponok.Gateway.Pagamento.Services.Cliente.Messages
{
    public class BaseMessageRequest
    {

        private Dictionary<string, object> _headers = new Dictionary<string, object>();

        /// <summary>
        /// Chave de Permissão para processar na adquirente
        /// </summary>
        public IReadOnlyDictionary<string, object> Headers
            => new ReadOnlyDictionary<string, object>(_headers);


        public void AddToken(string key, object value)
            => _headers.Add(key, value);
    }
}
