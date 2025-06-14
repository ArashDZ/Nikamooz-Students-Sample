using SampleApp.Core.Contracts.Students.Exceptions;
using SampleApp.Core.Contracts.Students.Queries;
using SampleApp.Core.RequestResponse.Students;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace SampleApp.Core.ApplicationService.Students.Queries
{
    public class GetByIdQueryHandler(IStudentQueryRepository repository, ZaminServices zaminServices)
        : QueryHandler<StudentGetByIdModel, StudentViewModel>(zaminServices)
    {
        public override async Task<QueryResult<StudentViewModel>> Handle(StudentGetByIdModel query)
        {
            var student = await repository.GetStudentById(query.Id)
                ?? throw new StudentNotFoundException(query.Id);

            return Result(student);
        }
    }
}
