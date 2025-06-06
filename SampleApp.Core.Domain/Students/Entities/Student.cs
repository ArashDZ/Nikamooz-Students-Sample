using SampleApp.Core.Domain.Students.Enums;
using System.Diagnostics.CodeAnalysis;
using Zamin.Core.Domain.Entities;

namespace SampleApp.Core.Domain.Students.Entities
{
    public class Student : AggregateRoot<int>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public short StudentNo { get; set; }
        public byte Grade { get; set; }
        public List<StudentAddress> Addresses { get; set; } = [];
        public string? ImageId { get; set; }

        private Student() : base() { }

        public static Student Create(
            string firstName,
            string lastName,
            byte Grade,
            [NotNull] List<StudentAddress> addresses,
            string? ImageId = null)
        {
            if (addresses?.Any(address => address.AddressType == AddressType.Home) != true)
            {
                throw new ArgumentException("Home address is required.", nameof(addresses));
            }

            return new Student
            {
                FirstName = firstName,
                LastName = lastName,
                Grade = Grade,
                Addresses = addresses,
                ImageId = ImageId
            };
        }
    }
}
