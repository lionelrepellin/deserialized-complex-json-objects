using DeserializedComplexJsonObjects.JsonUtilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeserializedComplexJsonObjects.Models
{
    //[JsonConverter(typeof(FormConverter))]
    public interface IForm
    {
        string Type { get; }
        double CalculateArea();
        bool IsValid();
    }
}