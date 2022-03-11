namespace DentalClinic.Api.Extensions {
    public static class AddCors {
        public static void AddCorsAndConfigure(this IServiceCollection services) {
            services.AddCors(options => options.AddPolicy("DentalClinicAngularFront", builder =>
                builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(o => true)));
        }
    }
}
