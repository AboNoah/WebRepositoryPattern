using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfWork.EF.DA
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register DbContext
            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MyConn")));

            // Register repositories
            // services.AddScoped<IRepository, Repository>();

            // Register other infrastructure services (e.g., email services)
            // services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }
}