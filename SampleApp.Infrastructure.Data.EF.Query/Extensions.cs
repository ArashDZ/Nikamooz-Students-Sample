using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SampleApp.Core.Contracts.Students.Queries;
using SampleApp.Infrastructure.Data.EF.Query.Context;
using SampleApp.Infrastructure.Data.EF.Query.Students.Repositories;

namespace SampleApp.Infrastructure.Data.EF.Query
{
    public static class Extensions
    {
        public static void AddSampleAppQueryDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SampleAppQueryDbContext>(builderOptions =>
            {
                builderOptions.UseSqlServer(connectionString);
            });
        }

        public static void AddEfStudentQueryRepository(this IServiceCollection services)
        {
            services.AddScoped<IStudentQueryRepository, StudentQueryRepository>();
        }
    }
}
