namespace GatewayApiClient.Serialization {

    internal interface ISerializer {

        /// <summary>
        /// Deserializes an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializedObject"></param>
        /// <returns></returns>
        T DeserializeObject<T>(string serializedObject);

        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        string SerializeObject<T>(T obj);
    }
}