using SampleApp.Core.Domain.Students.Events;
using System.Text.Json;
using Zamin.Core.Contracts.ApplicationServices.Events;

namespace SampleApp.Core.ApplicationService.Students.Events
{
    public class StdentCreatedHandler : IDomainEventHandler<StudentCreated>
    {
        public async Task Handle(StudentCreated studentCreatedEvent)
        {
            Console.WriteLine(JsonSerializer.Serialize(studentCreatedEvent));
        }
    }
}
