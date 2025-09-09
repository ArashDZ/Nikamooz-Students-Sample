using Zamin.Core.Domain.Events;

namespace SampleApp.Core.Domain.Students.Events
{
    public record StudentCreated : IDomainEvent
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
