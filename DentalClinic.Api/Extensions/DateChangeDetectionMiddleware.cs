using DentalClinic.Api.Hubs;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Services;
using Microsoft.AspNetCore.SignalR;
namespace DentalClinic.Api.Extensions {
    public static class DateChangeDetectionMiddleware {
        public static void UseDataChangeDetection(this IApplicationBuilder app) {
            app.Use(async (context, next) => {
                var method = context.Request.Method;
                var path = context.Request.Path;
                var domainServices = context.RequestServices.GetRequiredService<IDomainServices>();
                if (method == "POST" || method == "PUT" || method == "DELETE" || path.StartsWithSegments("/api/AppUser/allDoctors") ||
                                                                                 path.StartsWithSegments("/api/AppUser/allEmployees")) {
                    var hubContext = context.RequestServices.GetRequiredService<IHubContext<CacheHub>>();
                    await hubContext.Clients.All.SendAsync("invalidateCache", path);
                }
                if ((method == "PUT" || method == "DELETE") && path.StartsWithSegments("/api/Role")) {
                    var hubContext = context.RequestServices.GetRequiredService<IHubContext<RoleChangeDetectionHub>>();
                    Guid roleId = new Guid(context.Request.Query["Id"]);
                    Role r = await domainServices.RoleService.GetByIdAsync(roleId);
                    List<Guid> effectedUser = (List<Guid>) await domainServices.AppUserService.GetGuidsByRoleName(r.RoleName);
                    foreach (var user in effectedUser)
                        await hubContext.Clients.User(user.ToString()).SendAsync("logOut");
                }
                await next.Invoke();
                if (method != "GET" && path.StartsWithSegments("/api/Visit")) {
                    var hubContext = context.RequestServices.GetRequiredService<IHubContext<LiveBoardHub>>();
                    await hubContext.Clients.All.SendAsync("updateVisitBoard", await domainServices.VisitService.GetTodaysVisits());
                }
            });
        }
    }
}
