using SampleApp.Core.Domain.Students.Entities;
using SampleApp.Core.RequestResponse.Students;
using System.Diagnostics.CodeAnalysis;
using Zamin.Core.Contracts.Data.Commands;

namespace SampleApp.Core.Contracts.Students.Queries
{
    public interface IStudentCommandRepository : ICommandRepository<Student, int>
    {
        Task<StudentViewModel> AddStudent([NotNull] StudentAddModel student);
    }
}
