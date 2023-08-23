namespace MiCamioncito.Models
{
    public class Vehicle
    {
        public int IDVehicle { get; set; }
        public decimal CapacityCubicMeters { get; set; }
        public decimal FuelConsumptionPerKm { get; set; }
        public decimal AvailableDistanceKm { get; set; }
        public string? AvailabilityStartDate { get; set; }
        public string? AvailabilityEndDate { get; set; }
        public decimal DepreciationCostPerKm { get; set; }
        public string? CargoType { get; set; }
    }
}
