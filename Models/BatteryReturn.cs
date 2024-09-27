namespace api.Models
{
    public class BatteryReturn
    {
        public int Id { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string? Endorsedby { get; set; }
        public int? BatteryId { get; set; }
        public BatteryReceiving? BReceiving { get; set; }

    }
}
