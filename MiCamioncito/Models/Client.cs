namespace MiCamioncito.Models
{
    public class Client
    {
        public int IDClient { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public decimal CargoPercentage { get; set; }
        public string? ReceptionAddress { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? RequiredDocumentation { get; set; }
    }
}
