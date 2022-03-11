using System.Text.Json.Serialization;
namespace DentalClinic.Api.Extensions {
    public static class AddControllersJsonOptions {
        public static void AddControllersWithJsonOptions (this IServiceCollection services) {
            services.AddControllers().AddJsonOptions(options => {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.MaxDepth = 100;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        }
    }
}
