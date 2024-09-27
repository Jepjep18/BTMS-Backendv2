namespace api.DTO
{
    public class TireTransferDto
    {
        public DateTime? TransferDate { get; set; } // Nullable DateTime for Transfer Date
        public string ItemCategory { get; set; }
        public string ItemDescription { get; set; }
        public string BusinessUnitFrom { get; set; }
        public string BusinessUnitTo { get; set; }
        public string PlateNoFrom { get; set; }
        public string PlateNoTo { get; set; }
        public string Tirebrand { get; set; }
        public string Tiresize { get; set; }
        public string TireSerial { get; set; }
        public string ItemCode { get; set; }

        public string TireType { get; set; }

        public string Status { get; set; }


    }
}
