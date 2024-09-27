namespace api.Models
{
    public class TireTransfer
    {
        public int Id { get; set; }
        public DateTime? TransferDate { get; set; }
        public string? BusinessUnitFrom { get; set; }
        public string? BusinessUnitTo { get; set; }
        public string? PlateNoFrom { get; set; }
        public string? PlateNoTo { get; set; }
        public int? ReleasingId { get; set; }
        public TireReleasing? TireReleasing { get; set; }
    }
}
