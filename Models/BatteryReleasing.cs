namespace api.Models
{
    public class BatteryReleasing
    {
        public int Id { get; set; }
        public string? BusinessUnit { get; set; }
        public string? Imjno { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Receivedby { get; set; }
        public string? UserplateNo { get; set; }
        public string? Remarks { get; set; }
        public int? BatteryId { get; set; }
        public BatteryReceiving? BReceiving { get; set; }
        public ICollection<BatteryReturn>? BatteryReturn { get; set; } // Update this line

        public ICollection<BatteryTransfer>? BatteryTransfer { get; set; }
    }
}
