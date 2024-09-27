namespace api.DTO
{
    public class ReleaseMultipleTireItemsDto
    {
        public List<int> TireIds { get; set; }  // List of tire IDs to be released
        public string? Company { get; set; }    // Company involved in releasing
        public string? Imjno { get; set; }      // IMJ number
        public string? Driver { get; set; }     // Driver name
        public string? PlateNo { get; set; }    // Plate number
        public string? Abfiserialno { get; set; }  // ABFI serial number
        public string? Remarks { get; set; }    // Additional remarks
        public DateTime? ReleaseDate { get; set; }  // Date of release
        public string? Receivedby { get; set; } // Person who received the tire(s)
    }
}
