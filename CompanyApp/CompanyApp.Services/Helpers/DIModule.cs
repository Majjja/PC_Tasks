using CompanyApp.DataAccess.Context;
using CompanyApp.DataAccess.Interfaces;
using CompanyApp.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyApp.Business.Helpers
{
    public static class DIModule
    {
        public static IServiceCollection RegisterModule(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IRepository<StoreRepository>, StoreRepository>();
            services.AddDbContext<CompanyDbContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
        }
    }
}
