namespace api.DTO
{
    public class ReleaseMultipleItemsDto
    {
        public List<int> BatteryIds { get; set; }
        public string BusinessUnit { get; set; }
        public string Imjno { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Receivedby { get; set; } // This is the missing property
        public string UserPlateNo { get; set; }
        public string Remarks { get; set; }
    }

}
