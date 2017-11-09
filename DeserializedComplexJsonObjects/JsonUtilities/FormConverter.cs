using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeserializedComplexJsonObjects.Entities;

namespace DeserializedComplexJsonObjects.JsonUtilities
{
    public class FormConverter : JsonCreationConverter<IForm>
    {
        private readonly string _namespace = "DeserializedComplexJsonObjects.Entities";
        private readonly IEnumerable<string> _acceptedTypes = new List<string> { "CIRCLE", "RECTANGLE", "SQUARE", "TRIANGLE" };

        protected override IForm Create(Type objectType, JObject jObject)
        {
            if (jObject.Type == JTokenType.Object)
            {
                if (!FieldExists("type", jObject))
                    throw new NotImplementedException("The 'type' property does not exist.");

                var jToken = jObject["type"];
                var type = jToken.Value<string>();

                var typeFound = _acceptedTypes.FirstOrDefault(t => t.Equals(type, StringComparison.InvariantCultureIgnoreCase));
                if (typeFound == null)
                    throw new NotImplementedException($"The type '{type}' was not implemented.");

                return (IForm)Activator.CreateInstance(Type.GetType($"{_namespace}.{type}", true, true));
            }

            throw new ArgumentException();
        }

        private bool FieldExists(string fieldName, JObject jObject)
        {
            return jObject[fieldName] != null;
        }
    }
}