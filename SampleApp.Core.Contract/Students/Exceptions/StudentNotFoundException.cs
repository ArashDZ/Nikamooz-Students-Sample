using SampleApp.Core.Contracts.Common.Exceptions;

namespace SampleApp.Core.Contracts.Students.Exceptions
{
    public class StudentNotFoundException(int id) : NotFoundException(GetMessage(id))
    {
        private static string GetMessage(int id) => $"No student with with id {id} found!";
    }
}
