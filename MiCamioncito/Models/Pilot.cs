namespace MiCamioncito.Models
{
    public class Pilot
    {
        public int idPilot { get; set; }
        public string? Name { get; set; }
        public int AvailableTime { get; set; }
        public string? AvailabilityStartDate { get; set; }
        public string? AvailabilityEndDate { get; set; }
        public decimal PerDiem { get; set; }
        public decimal AdditionalExpenses { get; set; }

    }
}
