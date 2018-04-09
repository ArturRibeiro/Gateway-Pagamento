using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace GatewayApiClient.Serialization {

    internal class JsonSerializer : ISerializer {

        public string SerializeObject<T>(T obj) {

            if (obj == null) { return null; }

            string serializedString = string.Empty;

            // DataContract Json serialization class
            XmlObjectSerializer serializer = new DataContractJsonSerializer(typeof(T));

            using (MemoryStream memoryStream = new MemoryStream()) {

                // Serializes the object into a memory stream
                serializer.WriteObject(memoryStream, obj);

                // Gets an UTF8 string from the stream.
                serializedString = Encoding.UTF8.GetString(memoryStream.ToArray());
            }

            return serializedString;
        }

        public T DeserializeObject<T>(string serializedObject) {

            // DataContract Json serialization class
            XmlObjectSerializer deserializer = new DataContractJsonSerializer(typeof(T));

            T obj;

            // Gets the string corresponding bytes
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(serializedObject))) {

                // Deserializes the string into the specified type.
                obj = (T)deserializer.ReadObject(ms);
            }

            return obj;
        }
    }
}
