namespace api.Models
{
    public class BatteryReceiving
    {
        public int Id { get; set; }
        public DateTime? DateReceived { get; set; }
        public string? Receivedby { get; set; }
        public int? DrsiNo { get; set; }
        public int? PoNo { get; set; }
        public string? ItemCode { get; set; }
        public string? Supplier { get; set; }
        public string? ItemDescription { get; set; }
        public int? Quantity { get; set; }
        public string? Unitofmeasurement { get; set; }
        public string? Batteryserial { get; set; }
        public string? DebossedNo { get; set; }
        public string? Status { get; set; }
        public string? ItemCategory { get; set; } = "Battery";



        public BatteryReleasing? BatteryReleasing { get; set; }
    }
}
