using SampleApp.Core.Contracts.Students.Queries;
using SampleApp.Core.RequestResponse.Students;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace SampleApp.Core.ApplicationService.Students.Queries
{
    public class GetFilteredStudentsQueryHandler(IStudentQueryRepository repository, ZaminServices zaminServices)
        : QueryHandler<StudentFilterModel, List<StudentListModel>>(zaminServices)
    {
        public override async Task<QueryResult<List<StudentListModel>>> Handle(StudentFilterModel query)
        {
            List<StudentListModel> students = await repository.GetFilteredStudents(query);

            return Result(students);
        }
    }
}
