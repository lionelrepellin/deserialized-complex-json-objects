using DeserializedComplexJsonObjects.Models;
using System;

namespace DeserializedComplexJsonObjects.Tests
{
    public partial class FormConverterTests
    {
        public class Fake : IForm
        {
            public string Type => "HEXAGONE";

            public double Radius { get; set; }
            public double SideLength { get; set; }

            public double CalculateArea()
            {
                throw new NotImplementedException();
            }

            public bool IsValid()
            {
                return true;
            }
        }
    }
}
