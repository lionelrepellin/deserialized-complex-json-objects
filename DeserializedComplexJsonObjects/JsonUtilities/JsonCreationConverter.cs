using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace DeserializedComplexJsonObjects.JsonUtilities
{
    /// <summary>
    /// Converter for json
    /// </summary>
    /// <see cref="https://stackoverflow.com/questions/8030538/how-to-implement-custom-jsonconverter-in-json-net-to-deserialize-a-list-of-base"/>
    /// <typeparam name="T"></typeparam>
    public abstract class JsonCreationConverter<T> : JsonConverter
    {
        /// <summary>
        /// Create an instance of objectType, based properties in the JSON object
        /// </summary>
        /// <param name="objectType">type of object expected</param>
        /// <param name="jObject">
        /// contents of JSON object that will be deserialized
        /// </param>
        /// <returns></returns>
        protected abstract T Create(Type objectType, JObject jObject);

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            // Load JObject from stream
            var jObject = JObject.Load(reader);

            // Create target object based on JObject
            T target = Create(objectType, jObject);

            // Populate the object properties
            using (JsonReader jObjectReader = CopyReaderForObject(reader, jObject))
            {
                serializer.Populate(jObjectReader, target);
            }

            return target;
        }

        /// <summary>
        /// Creates a new reader for the specified jObject by copying the settings from an existing reader.
        /// </summary>
        /// <param name="reader">The reader whose settings should be copied.</param>
        /// <param name="jObject">The jObject to create a new reader for.</param>
        /// <returns>The new disposable reader.</returns>
        protected static JsonReader CopyReaderForObject(JsonReader reader, JObject jObject)
        {
            var jsonReader = jObject.CreateReader();
            jsonReader.Culture = reader.Culture;
            jsonReader.DateFormatString = reader.DateFormatString;
            jsonReader.DateParseHandling = reader.DateParseHandling;
            jsonReader.DateTimeZoneHandling = reader.DateTimeZoneHandling;
            jsonReader.FloatParseHandling = reader.FloatParseHandling;
            jsonReader.MaxDepth = reader.MaxDepth;
            jsonReader.SupportMultipleContent = reader.SupportMultipleContent;
            return jsonReader;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}