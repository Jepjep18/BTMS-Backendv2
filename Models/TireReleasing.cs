namespace api.Models
{
    public class TireReleasing
    {
        public int Id { get; set; }
        public string? Company { get; set; }
        public string? Imjno { get; set; }
        public string? Driver { get; set; }
        public string? PlateNo { get; set; }
        public string? Abfiserialno { get; set; }
        public string? Remarks { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Receivedby { get; set; }
        public int? TireId { get; set; }
        public TireReceiving? TReceiving { get; set; }
        public TireReturn? TireReturn { get; set; }

        public ICollection<TireTransfer>? TireTransfer { get; set; }
    }
}
