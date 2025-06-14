using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SampleApp.Infrastructure.Data.EF.Query.Students.Configs
{
    internal class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> entityType)
        {
            entityType
                .HasKey(address => address.Id);
        }
    }
}
