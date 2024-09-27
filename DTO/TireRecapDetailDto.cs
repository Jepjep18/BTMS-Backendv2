namespace api.DTO
{
    // DTO for combined TireRecap, TireReturn, and TireReceiving data
    public class TireRecapDetailDto
    {
        public int TireRecapId { get; set; }
        public DateTime? RecappedDate { get; set; } // Nullable DateTime
        public string TireRecapEndorsedBy { get; set; }
        public string Purpose { get; set; }
        public DateTime? DateReceived { get; set; } // Nullable DateTime
        public string Receivedby { get; set; }
        public string DrciNo { get; set; }
        public string PoNo { get; set; }
        public string Supplier { get; set; }
        public string ItemCode { get; set; }
        public int? Quantity { get; set; } // Nullable int
        public string Unitofmeasurement { get; set; }
        public string Tiresize { get; set; }
        public string Tirebrand { get; set; }
        public string TireSerial { get; set; }
        public string DebossedNo { get; set; }
        public string Status { get; set; }
        public string TireType { get; set; }
        public string ItemCategory { get; set; }
    }


}
