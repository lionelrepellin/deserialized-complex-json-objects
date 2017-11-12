using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeserializedComplexJsonObjects.Models
{
    public interface IForm
    {
        string Type { get; }
        double CalculateArea();
        bool IsValid();
    }
}