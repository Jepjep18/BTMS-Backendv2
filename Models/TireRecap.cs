namespace api.Models
{
    public class TireRecap
    {
        public int Id { get; set; }

        public DateTime? RecappedDate { get; set; }

        public string EndorsedBy { get; set; }

        // Foreign key for TireReturn
        public int? TireReturnId { get; set; }

        // Navigation property
        public TireReturn? TireReturn { get; set; }
    }
}
