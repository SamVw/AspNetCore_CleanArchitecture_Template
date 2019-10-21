using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var builder = new SqlConnectionStringBuilder(
                configuration.GetConnectionString("TemplateDatabase"));
            builder.Password = configuration["DbPassword"];
            string connectionString = builder.ConnectionString;

            services.AddDbContext<TemplateDbContext>(options =>
                options.UseSqlServer(connectionString)
                    .EnableSensitiveDataLogging());

            services.AddScoped<ITemplateDbContext>(provider => provider.GetService<TemplateDbContext>());

            return services;
        }
    }
}
