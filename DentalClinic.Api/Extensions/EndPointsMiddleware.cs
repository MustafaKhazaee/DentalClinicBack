using DentalClinic.Api.Hubs;
namespace DentalClinic.Api.Extensions {
    public static class EndPointsMiddleware {
        public static void UseEnpointsAndHubs (this IApplicationBuilder app) {
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                endpoints.MapHub<CacheHub>("/api/cacheHub");
                endpoints.MapHub<LiveBoardHub>("/api/liveBoardHub");
                endpoints.MapHub<RoleChangeDetectionHub>("/api/roleChangeDetectionHub");
            });
        }
    }
}
