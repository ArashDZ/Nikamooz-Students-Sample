using Zamin.Core.RequestResponse.Queries;

namespace SampleApp.Core.RequestResponse.Students
{
    public class StudentGetByIdModel : IQuery<StudentViewModel>
    {
        public int Id { get; set; }
    }
}
