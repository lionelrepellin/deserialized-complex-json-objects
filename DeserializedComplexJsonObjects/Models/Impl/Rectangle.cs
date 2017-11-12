namespace DeserializedComplexJsonObjects.Models
{
    public class Rectangle : IForm
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public string Type => "RECTANGLE";

        public double CalculateArea()
        {
            return Length * Width;
        }

        public bool IsValid()
        {
            return Length > 0 && Width > 0 && Length > Width;
        }
    }
}