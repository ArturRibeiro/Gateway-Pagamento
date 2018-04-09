using System;

namespace GatewayApiClient.Serialization {

    internal class SerializerFactory {

        public static ISerializer Create(string format) {

            if (string.Equals(format, "json", StringComparison.InvariantCultureIgnoreCase) == true) {
                return new JsonSerializer();
            }
            else if (string.Equals(format, "xml", StringComparison.InvariantCultureIgnoreCase) == true) {
                return new XmlSerializer();
            }
            else {
                throw new NotImplementedException(string.Format("The specified format '{0}' is not implemented.", format));
            }
        }
    }
}
