using Microsoft.EntityFrameworkCore;
using SampleApp.Core.Contracts.Students.Queries;
using SampleApp.Core.RequestResponse.Addresses;
using SampleApp.Core.RequestResponse.Students;
using SampleApp.Infrastructure.Data.EF.Query.Context;
using Zamin.Infra.Data.Sql.Queries;

namespace SampleApp.Infrastructure.Data.EF.Query.Students.Repositories
{
    internal class StudentQueryRepository(SampleAppQueryDbContext context)
        : BaseQueryRepository<SampleAppQueryDbContext>(context), IStudentQueryRepository
    {
        private readonly string defaultImageId = "123456";
        private string GetImageUrl(string? imageId)
        {
            if (imageId is null) return $"www.image-store.com/images/{defaultImageId}";

            return $"www.image-store.com/images/{imageId}";
        }
        private static StudentListModel MapStudentToListModel(Student student)
        {
            return new()
            {
                Id = student.Id,
                FullName = $"{student.FirstName} {student.LastName}",
                Grade = student.Grade,
                StudentNo = student.StudentNo,
            };
        }

        private AddressViewModel MapStudentAddressToAddressViewModel(StudentAddress studentAddress)
        {
            return new()
            {
                AddressType = studentAddress.AddressType,
                City = studentAddress.Address.City,
                Street = studentAddress.Address.Street,
                Alley = studentAddress.Address.Alley,
                BuildingNo = studentAddress.Address.BuildingNo,
            };
        }

        private StudentViewModel MapStudentToViewModel(Student student)
        {
            return new()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Grade = student.Grade,
                StudentNo = student.StudentNo,
                ImageUrl = GetImageUrl(student.ImageId),
                Addresses = student.Addresses.Select(MapStudentAddressToAddressViewModel).ToList()
            };
        }
        public async Task<List<StudentListModel>> GetFilteredStudents(StudentFilterModel? studentFilterModel)
        {
            IQueryable<Student> students = context.Students
                .Include(student => student.Addresses)
                .ThenInclude(studentAddress => studentAddress.Address);

            if (studentFilterModel is null) return await students
                    .Select(student => MapStudentToListModel(student))
                    .ToListAsync();

            if (studentFilterModel.Grade.HasValue)
            {
                students = students
                    .Where(student => student.Grade == studentFilterModel.Grade);
            }

            return await students
                    .Select(student => MapStudentToListModel(student))
                    .ToListAsync();
        }

        public async Task<StudentViewModel?> GetStudentById(int id)
        {
            Student? student = await context.Students
                .Include(student => student.Addresses)
                .ThenInclude(studentAddress => studentAddress.Address)
                .FirstOrDefaultAsync(student => student.Id == id);

            if (student is null) return null;

            return MapStudentToViewModel(student);
        }
    }
}
