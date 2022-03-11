using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace DentalClinic.Api.Extensions {
    public static class AddJwtAuthenticationExtention {
        public static void AddJWTAuthentication(this IServiceCollection services, IConfiguration configuration) {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.Unicode.GetBytes(configuration["Jwt:IssuerSigninKey"])),
                        ValidAudience = configuration["Jwt:ValidAudience"],
                        ValidIssuer = configuration["Jwt:ValidIssuer"],
                        ValidateIssuerSigningKey = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuer = true,
                    };
                    options.Events = new JwtBearerEvents {
                        OnMessageReceived = context => {
                            var Token = context.Request.Query["token"];
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(Token) && (path.StartsWithSegments("/api/cacheHub") ||
                                                                 path.StartsWithSegments("/api/liveBoardHub") ||
                                                                 path.StartsWithSegments("/api/roleChangeDetectionHub")))
                                context.Token = Token;
                            return Task.CompletedTask;
                        }
                    };
                });
        }
    }
}
