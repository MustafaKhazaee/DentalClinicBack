using DentalClinic.Domain.Repository;
using DentalClinic.Domain.Services;
using DentalClinic.Infrastructure.Repository;
using DentalClinic.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace DentalClinic.Infrastructure {
    public static class DependencyInjection {
        public static void AddInfrastructureServices (this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("DentalClinic")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDomainServices, DomainServices>();
        }
    }
}
