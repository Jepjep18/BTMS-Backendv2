﻿namespace api.Models
{
    public class BatteryReturn
    {
        public int Id { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string? Endorsedby { get; set; }
        public int? BatteryReleasingId { get; set; }
        public BatteryReleasing? BatteryReleasing { get; set; }

    }
}
