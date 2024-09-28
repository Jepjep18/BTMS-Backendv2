namespace api.DTO
{
    public class BatteryReturnResponseDto
    {
        public int BatteryReturnId { get; set; }
        public DateTime? ReturnDate { get; set; } // Nullable DateTime
        public string ReturnEndorsedBy { get; set; }
        public int? BatteryReturnBatteryId { get; set; } // Nullable int
        public string BusinessUnit { get; set; }
        public string Imjno { get; set; }
        public DateTime? ReleaseDate { get; set; } // Nullable DateTime
        public string ReleasedReceivedBy { get; set; }
        public string UserplateNo { get; set; }
        public string Remarks { get; set; }
        public int ReceivingId { get; set; }
        public DateTime? ReceivedDate { get; set; } // Nullable DateTime
        public string ReceivedReceivedBy { get; set; }
        public string DrsiNo { get; set; } // Assuming these are string
        public string PoNo { get; set; } // Assuming these are string
        public string ItemCode { get; set; }
        public string Supplier { get; set; }
        public string ItemDescription { get; set; }
        public string Batteryserial { get; set; }
        public string DebossedNo { get; set; }
    }
}
