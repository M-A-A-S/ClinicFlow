using ClinicFlow.Application.Services;
using ClinicFlow.Infrastructure.Data;
using ClinicFlow.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddScoped<IChronicConditionService, ChronicConditionService>();
            services.AddScoped<IAllergyService, AllergyService>();

            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"))
                .LogTo(Console.WriteLine, LogLevel.Debug);
            });

            return services;
        }

    }
}
