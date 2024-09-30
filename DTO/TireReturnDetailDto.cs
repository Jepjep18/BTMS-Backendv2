namespace api.DTO
{
    public class TireReturnDetailDto
    {
        public int TireReturnId { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string EndorsedBy { get; set; }
        public string Purpose { get; set; }
        public int? TireReleasingId { get; set; } // Nullable if it can be null
        public string Company { get; set; }
        public string Imjno { get; set; }
        public string Driver { get; set; }
        public string PlateNo { get; set; }
        public string Abfiserialno { get; set; }
        public string Remarks { get; set; }
        public DateTime? ReleaseDate { get; set; } // Nullable if it can be null
        public string Receivedby { get; set; }
        public int? TireId { get; set; } // Nullable if it can be null
        public int? TireReceivingId { get; set; } // Nullable if it can be null
        public DateTime? DateReceived { get; set; } // Nullable if it can be null
        public string TireReceivedBy { get; set; }
        public string DrciNo { get; set; }
        public string PoNo { get; set; }
        public string Supplier { get; set; }
        public string ItemCode { get; set; }
        public int? Quantity { get; set; } // Nullable if it can be null
        public string Unitofmeasurement { get; set; }
        public string Tiresize { get; set; }
        public string Tirebrand { get; set; }
        public string TireSerial { get; set; }
        public string DebossedNo { get; set; }
        public string TireReceivingRemarks { get; set; }
        public string TireReceivingStatus { get; set; }
        public string TireType { get; set; }
        public string ItemCategory { get; set; }
    }

}
