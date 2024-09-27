namespace api.DTO
{
    public class TireReturnDTO
    {
        public DateTime ReceivedDate { get; set; }
        public string EndorsedBy { get; set; }
        public string Purpose { get; set; }
        public string ReceivedBy { get; set; }
        public string ItemDescription { get; set; }
        public string ItemCategory { get; set; }
        public int DrciNo { get; set; }
        public int PoNo { get; set; }
        public string SerialNo { get; set; }
        public string DebossedNo { get; set; }
    }
}
