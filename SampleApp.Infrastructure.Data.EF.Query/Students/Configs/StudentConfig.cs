using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleApp.Core.Domain.Students.Entities;

namespace SampleApp.Infrastructure.Data.EF.Query.Students.Configs
{
    internal class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> entityType)
        {
            entityType
                .HasKey(student => student.Id);

            entityType
                .HasMany(student => student.Addresses)
                .WithOne(studentAddress => studentAddress.Student)
                .HasForeignKey(studentAddress => studentAddress.StudentId)
                .HasPrincipalKey(student => student.Id);

            entityType
                .HasIndex(student => student.LastName);
        }
    }
}
