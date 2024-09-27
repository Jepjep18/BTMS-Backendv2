namespace api.DTOs
{
    public class BusinessUnitDTO
    {
        public int id { get; set; }
        public string? BusinessUnitCode { get; set; }
        public string? BusinessAddress { get; set; }
        public string? BU_Description { get; set; }
        public string? BU_Department { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class BusinessUnitUpdate
    {
        public string? BusinessUnitCode { get; set; }
        public string? BusinessAddress { get; set; }
        public string? BU_Description { get; set; }
        public string? BU_Department { get; set; }
    }
}
