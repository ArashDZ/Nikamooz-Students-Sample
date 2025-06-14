using SampleApp.Core.Contracts.Students.Exceptions;
using SampleApp.Core.Contracts.Students.Queries;
using SampleApp.Core.Domain.Students.Entities;
using SampleApp.Core.Domain.Students.Enums;
using SampleApp.Core.RequestResponse.Students;
using SampleApp.Infrastructure.Data.EF.Command.Context;
using System.Diagnostics.CodeAnalysis;
using Zamin.Infra.Data.Sql.Commands;

namespace SampleApp.Infrastructure.Data.EF.Command.Students.Repositories
{
    internal class StudentCommandRepository(SampleAppCommandDbContext context, IStudentQueryRepository queryRepository)
        : BaseCommandRepository<Student, SampleAppCommandDbContext, int>(context), IStudentCommandRepository
    {
        public async Task<StudentViewModel> AddStudent([NotNull] StudentAddModel student)
        {
            if (student.Addresses?.Any(address => address.AddressType == AddressType.Home) != true)
            {
                throw new NoHomeAddressException();
            }

            List<StudentAddress> studentAddresses = student.Addresses?.Select(address =>
            {
                var newAddresss = new Address
                {
                    Alley = address.Alley,
                    City = address.City,
                    BuildingNo = address.BuildingNo,
                    Street = address.Street,
                };

                context.Addresses.Add(newAddresss);

                var newStudentAddress = new StudentAddress()
                {
                    AddressType = address.AddressType,
                    Address = newAddresss,
                };

                return context.StudentAddresses.Add(newStudentAddress).Entity;
            }).ToList() ?? [];

            Student newStudent = Student.Create(
                student.FirstName,
                student.LastName,
                student.Grade,
                studentAddresses);

            newStudent = context.Students.Add(newStudent).Entity;

            await CommitAsync();
#pragma warning disable CS8603 // Possible null reference return.
            return await queryRepository.GetStudentById(newStudent.Id);
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
