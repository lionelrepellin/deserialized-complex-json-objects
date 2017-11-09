using DeserializedComplexJsonObjects.Entities;
using DeserializedComplexJsonObjects.JsonUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeserializedComplexJsonObjects.Models
{
    public class FormModel
    {
        [JsonConverter(typeof(FormConverter))]
        public IForm Form { get; set; }
    }
}