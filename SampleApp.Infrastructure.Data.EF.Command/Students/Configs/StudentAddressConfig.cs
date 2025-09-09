using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleApp.Core.Domain.Students.Entities;

namespace SampleApp.Infrastructure.Data.EF.Command.Students.Configs
{
    internal class StudentAddressConfig : IEntityTypeConfiguration<StudentAddress>
    {
        public void Configure(EntityTypeBuilder<StudentAddress> entityType)
        {
            entityType
                .HasKey(studentAddress => studentAddress.Id);

            entityType
                .HasOne(studentAddress => studentAddress.Address)
                .WithMany()
                .HasForeignKey(studentAddress => studentAddress.AddressId)
                .HasPrincipalKey(address => address.Id)
                .OnDelete(DeleteBehavior.Restrict);

            entityType
                .HasOne(studentAddress => studentAddress.Student)
                .WithMany(student => student.Addresses)
                .HasForeignKey(studentAddress => studentAddress.StudentId)
                .HasPrincipalKey(student => student.Id);
        }
    }
}
