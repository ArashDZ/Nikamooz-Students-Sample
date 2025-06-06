using Microsoft.EntityFrameworkCore;
using SampleApp.Core.Domain.Students.Entities;
using SampleApp.Infrastructure.Data.EF.Command.Students.Configs;
using Zamin.Infra.Data.Sql.Commands;

namespace SampleApp.Infrastructure.Data.EF.Command.Context
{
    internal class SampleAppCommandDbContext : BaseCommandDbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<StudentAddress> StudentAddresses { get; set; }

        public SampleAppCommandDbContext(DbContextOptions<SampleAppCommandDbContext> contextOptions)
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
