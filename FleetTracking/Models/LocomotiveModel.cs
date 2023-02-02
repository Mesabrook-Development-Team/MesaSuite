namespace FleetTracking.Models
{
    public class LocomotiveModel
    {
        public long? LocomotiveModelID { get; set; }
        public string Name { get; set; }
        public decimal? FuelCapacity { get; set; }
        public decimal? WaterCapacity { get; set; }
        public decimal? Length { get; set; }
        public bool IsSteamPowered { get; set; }
        public byte[] Image { get; set; }
    }
}
