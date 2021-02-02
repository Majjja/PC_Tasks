using CompanyApp.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyApp.Business.Helpers
{
    public static class DIModule
    {
        public static IServiceCollection DIConnecting(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CompanyDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
