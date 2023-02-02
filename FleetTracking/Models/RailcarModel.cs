namespace FleetTracking.Models
{
    public class RailcarModel
    {
        public long? RailcarModelID { get; set; }
        public string Name { get; set; }
        public decimal? CargoCapacity { get; set; }
        public decimal? Length { get; set; }
        public enum Types
        {
            // Freight
            Box = 0,
            Tank = 1,
            Hopper = 2,
            Flat = 3,
            BulkheadFlat = 4,
            BulkheadStanchionFlat = 5,
            Centerbeam = 6,
            Autorack = 7,
            Gondola = 8,
            Well = 9,

            // Passenger
            Coach = 50,
            Diner = 51,
            Sleeper = 52,
            Baggage = 53,
            Mail = 54,
            Caboose = 55,
            Cab = 56
        }
        public Types Type { get; set; }
        public byte[] Image { get; set; }
    }
}
