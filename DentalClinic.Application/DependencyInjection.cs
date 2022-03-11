using DentalClinic.Application.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
namespace DentalClinic.Application {
    public static class DependencyInjection {
        public static void AddApplicationServices(this IServiceCollection services) {
            services.AddScoped<IApplicationServices, ApplicationServices>();
            services.AddSingleton<IUserIdProvider, AppUserIdProvider>();
        }
    }
}
