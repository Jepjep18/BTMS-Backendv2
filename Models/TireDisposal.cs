namespace api.Models
{
    public class TireDisposal
    {
        public int Id { get; set; }
        public DateTime DisposalDate { get; set; }
        public string EndorsedBy { get; set; }
        public int? TireReturnId { get; set; }
        public TireReturn? TireReturn { get; set; }
    }
}
