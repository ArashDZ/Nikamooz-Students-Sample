using AddressType = SampleApp.Core.Domain.Students.Enums.AddressType;
namespace SampleApp.Infrastructure.Data.EF.Query.Students
{
    public class StudentAddress
    {
        public Guid BusinessId { get; set; }
        public int Id { get; set; }
        public int AddressId { get; set; }
        public int StudentId { get; set; }
        public AddressType AddressType { get; set; }
        public Student Student { get; set; }
        public Address Address { get; set; }
    }
}
