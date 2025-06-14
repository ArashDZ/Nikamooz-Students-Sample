namespace SampleApp.Infrastructure.Data.EF.Query.Students
{
    public class Address
    {
        public int Id { get; set; }
        public Guid BusinessId { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Alley { get; set; }
        public string? BuildingNo { get; set; }

    }
}
