using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SampleApp.Infrastructure.Data.EF.Query.Context;

namespace SampleApp.Infrastructure.Data.EF.Query
{
    public static class Extensions
    {
        public static void AddSampleAppQueryDbContext(this IServiceCollection services, string connectionString) {
            services.AddDbContext<SampleAppQueryDbContext>(builderOptions =>
            {
                builderOptions.UseSqlServer(connectionString);
            });
        }
    }
}
