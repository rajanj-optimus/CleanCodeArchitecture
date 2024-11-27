using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Interfaces;
using MyApp.Infrastructure.Data;
using MyApp.Infrastructure.Repositories;

namespace MyApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Server=CPC-rajan-49C3P;Database=CleanCodeArc;Integrated Security=true;TrustServerCertificate=true;");
            });
            services.AddScoped<IEmployeeRepository,EmployeeRepository>();

            return services;
        }
    }
}
