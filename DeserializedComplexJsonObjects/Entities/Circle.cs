using System;

namespace DeserializedComplexJsonObjects.Entities
{
    public class Circle : IForm
    {
        public double Radius { get; set; }

        public string Type => "CIRCLE";

        public double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public bool IsValid()
        {
            return Radius > 0;
        }
    }
}