namespace MiCamioncito.Models
{
    public class Service
    {
        public int IDService { get; set; }
        public int IDVehicle { get; set; }
        public int IDPilot { get; set; }
        public int IDClient { get; set; }
        public string? ServiceDate { get; set; }
        public string? DeliveryDate { get; set; }
        public decimal TotalCost { get; set; }
    }
}
