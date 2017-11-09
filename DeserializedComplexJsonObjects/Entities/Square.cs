using System;

namespace DeserializedComplexJsonObjects.Entities
{
    public class Square : IForm
    {
        public double Length { get; set; }

        public string Type => "SQUARE";

        public double CalculateArea()
        {
            return Math.Pow(Length, 2);
        }

        public bool IsValid()
        {
            return Length > 0;
        }
    }
}