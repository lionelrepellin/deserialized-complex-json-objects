namespace DeserializedComplexJsonObjects.Entities
{
    public class Triangle : IForm
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public string Type => "TRIANGLE";

        public double CalculateArea()
        {
            return (Base * Height) / 2;
        }

        public bool IsValid()
        {
            return Base > 0 && Height > 0;
        }
    }
}