using SampleApp.Core.Domain.Students.Enums;
using Zamin.Core.Domain.Entities;

namespace SampleApp.Core.Domain.Students.Entities
{
    public class Address : Entity<int>
    {
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Alley { get; set; }
        public string? BuildingNo { get; set; }
    }
}
