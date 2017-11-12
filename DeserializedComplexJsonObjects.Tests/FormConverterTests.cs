using DeserializedComplexJsonObjects.JsonUtilities;
using DeserializedComplexJsonObjects.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using NFluent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace DeserializedComplexJsonObjects.Tests
{
    [TestFixture]
    public partial class FormConverterTests
    {
        private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.None
        };

        [Test]
        public void DeserializeSquare()
        {
            var form = new Square
            {
                Length = 10
            };

            var square = TestConverter<Square>(form);
            Check.That(square.CalculateArea()).IsEqualTo(100);
        }

        [Test]
        public void DeserializeTriangle()
        {
            var form = new Triangle
            {
                Base = 10,
                Height = 18
            };

            var triangle = TestConverter<Triangle>(form);
            Check.That(triangle.CalculateArea()).IsEqualTo(90);
        }

        [Test]
        public void TryToDeserializeAnonymousObject()
        {
            var anonymous = new
            {
                Width = 10,
                Height = 20
            };

            var json = JsonConvert.SerializeObject(anonymous, _settings);

            Check.ThatCode(() =>
            {
                JsonConvert.DeserializeObject<IForm>(json, new FormConverter());
            }).Throws<KeyNotFoundException>();
        }

        [Test]
        public void TryToDeserializeFakeForm()
        {
            var fake = new Fake();

            var json = JsonConvert.SerializeObject(fake, _settings);

            Check.ThatCode(() =>
            {
                JsonConvert.DeserializeObject<IForm>(json, new FormConverter());
            }).Throws<NotImplementedException>();
        }
        
        public T TestConverter<T>(IForm form)
        {
            // serialize form to json
            var json = JsonConvert.SerializeObject(form, _settings);

            // deserialize json to IForm
            var obj = JsonConvert.DeserializeObject<IForm>(json, new FormConverter());

            Check.That(obj).IsInstanceOf<T>();
            return (T)obj;
        }
    }
}
