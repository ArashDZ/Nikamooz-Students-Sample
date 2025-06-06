using Microsoft.EntityFrameworkCore;
using SampleApp.Core.Domain.Students.Entities;
using SampleApp.Infrastructure.Data.EF.Query.Students.Configs;
using Zamin.Infra.Data.Sql.Queries;

namespace SampleApp.Infrastructure.Data.EF.Query.Context
{
    internal class SampleAppQueryDbContext : BaseQueryDbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<StudentAddress> StudentAddresses { get; set; }

        public SampleAppQueryDbContext(DbContextOptions<SampleAppQueryDbContext> contextOptions)
            : base(contextOptions)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new StudentConfig());
            modelBuilder.ApplyConfiguration(new AddressConfig());
            modelBuilder.ApplyConfiguration(new StudentAddressConfig());
        }
    }
}
