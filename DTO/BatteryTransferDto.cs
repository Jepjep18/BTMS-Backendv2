namespace api.DTO
{
    public class BatteryTransferDto
    {
        public int Id { get; set; } // Add this line if not present
        public DateTime? TransferDate { get; set; } // Make TransferDate nullable
        public string ItemCategory { get; set; }
        public string ItemDescription { get; set; }
        public string BusinessUnitFrom { get; set; }
        public string BusinessUnitTo { get; set; }
        public string PlateNoFrom { get; set; }
        public string PlateNoTo { get; set; }
        public string Status { get; set; }
        public string ItemCode { get; set; }
        public string Supplier { get; set; }
        public int DrsiNo { get; set; }
        public int PoNo { get; set; }
        public DateTime DateReceived { get; set; }
        public string Batteryserial { get; set; }
        public string DebossedNo { get; set;}
        public int BatteryReceivingId { get; set; }

    }

}
