using System.Collections.Generic;
using System.IO;

namespace Scorponok.Shared.Fluent.HttpClient
{
    public class Settings
    {
        private const string REGISTRY_CONFIG_FILE = "REGISTRY_CONFIG_FILE";

        private IDictionary<string, string> _variables = new Dictionary<string, string>();

        public string PathWebHost { get; private set; }

        public IDictionary<string, string> Variables => _variables;

        /// <summary>
        /// Especifique o diretório raiz de conteúdo a ser usado pelo host.
        /// </summary>
        /// <param name="pathWebHost"></param>
        public void AddWebHostPath(string pathWebHost)
            => this.PathWebHost = pathWebHost;


        public void AddEnvironment(string variableName, string value)
        {
            if (variableName == REGISTRY_CONFIG_FILE)
                _variables.Add(variableName, Path.Combine(PathWebHost, value));
            else
                _variables.Add(variableName, value);
        }
    }

}
