namespace api.Models
{
    public class TireReturn
    {
        public int Id { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public string? EndorsedBy { get; set; }

        public string? Purpose { get; set; }

        public int? TireReleasingId { get; set; }

        public TireReleasing? TireReleasing { get; set; }

        // One-to-one relationship
        public TireRecap? TireRecap { get; set; }
        public TireDisposal? TireDisposal { get; set; }


    }
}
