using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SampleApp.Core.Contracts.Students.Queries;
using SampleApp.Infrastructure.Data.EF.Command.Context;
using SampleApp.Infrastructure.Data.EF.Command.Students.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Infra.Data.Sql.Commands.Interceptors;

namespace SampleApp.Infrastructure.Data.EF.Command
{
    public static class Extensions
    {
        public static IServiceCollection AddSampleAppCommandDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SampleAppCommandDbContext>(options =>
            {
                options.UseSqlServer(connectionString);

                // جایگزینی حروف عربی با فارسی ('ی' و 'ک') ـ
                options.AddInterceptors(new SetPersianYeKeInterceptor());

                // ثبت رویدادها
                options.AddInterceptors(new AddAuditDataInterceptor());
            });

            return services;
        }

        public static IServiceCollection AddEfStudentCommandRepository(this IServiceCollection services)
        {
            services.AddScoped<IStudentCommandRepository, StudentCommandRepository>();

            return services;
        }
    }
}
