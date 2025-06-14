using SampleApp.Core.RequestResponse.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Core.Contracts.Students.Queries
{
    public interface IStudentQueryRepository
    {
        Task<StudentViewModel?> GetStudentById(int id);
        Task<List<StudentListModel>> GetFilteredStudents(StudentFilterModel? studentFilterModel);
    }
}
