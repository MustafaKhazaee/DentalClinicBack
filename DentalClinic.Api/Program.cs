using DentalClinic.Infrastructure;
using DentalClinic.Application;
using DentalClinic.Api.Extensions;
using Microsoft.AspNetCore.Diagnostics;

namespace DentalClinic.Api {
    public class Program {
        public static void Main(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>()).Build().Run();
    }
    public class Startup {
        private IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public void ConfigureServices(IServiceCollection services) {
            services.AddInfrastructureServices(Configuration);
            services.AddEndpointsApiExplorer();
            services.AddApplicationServices(); // Keep it above AddSignalR()
            services.AddSwaggerGen();
            services.AddSignalR(o => o.EnableDetailedErrors = true);
            services.AddCorsAndConfigure();
            services.AddControllersWithJsonOptions();
            services.AddJWTAuthentication(Configuration);
            //services.AddLogging().addConsole
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.UseHttpsRedirection();
            app.UseExceptionHandling();
            app.UseRouting();
            app.UseCors("DentalClinicAngularFront");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseDataChangeDetection();
            app.UseEnpointsAndHubs();
        }
    }
}