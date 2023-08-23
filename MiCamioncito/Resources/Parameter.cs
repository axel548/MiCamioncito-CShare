namespace MiCamioncito.Resources
{
    public class Parameter
    {
        private string v;
        private double perDiem;
        private DateTime dateStartAvailability;

        public Parameter(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public Parameter(string v, double perDiem)
        {
            this.v = v;
            this.perDiem = perDiem;
        }

        public Parameter(string v, DateTime dateStartAvailability)
        {
            this.v = v;
            this.dateStartAvailability = dateStartAvailability;
        }

        public string Name { get; set; }
        public string Value { get; set; }
    }
}
