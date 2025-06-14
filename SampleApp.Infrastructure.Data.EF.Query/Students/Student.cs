using SampleApp.Core.Domain.Students.Entities;

namespace SampleApp.Infrastructure.Data.EF.Query.Students
{
    public class Student
    {
        public int Id { get; set; }
        public Guid BusinessId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public short StudentNo { get; set; }
        public byte Grade { get; set; }
        public List<StudentAddress> Addresses { get; set; } = [];
        public string? ImageId { get; set; }
    }
}
