using Zamin.Core.RequestResponse.Queries;

namespace SampleApp.Core.RequestResponse.Students
{
    public class StudentFilterModel : IQuery<List<StudentListModel>>
    {
        public byte? Grade { get; set; }
    }
}
