using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiSAT.Eshop.Application.Common.Interfaces;

namespace RiSAT.Eshop.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RiSATeshopDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("NorthwindDatabase")));

            services.AddScoped<IRiSATeshopDbContext>(provider => provider.GetService<RiSATeshopDbContext>());

            return services;
        }
    }
}
