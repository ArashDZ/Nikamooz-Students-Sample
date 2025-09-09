using SampleApp.Core.Contracts.Students.Queries;
using SampleApp.Core.RequestResponse.Students;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace SampleApp.Core.ApplicationService.Students.Commands
{
    public class AddStudentCommandHandler(ZaminServices zaminServices, IStudentCommandRepository repository)
        : CommandHandler<StudentAddModel, StudentViewModel>(zaminServices)
    {
        public override async Task<CommandResult<StudentViewModel>> Handle(StudentAddModel request)
        {
            return Ok(await repository.AddStudent(request));
        }

    }
}
