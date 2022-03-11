using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
namespace DentalClinic.Api.Hubs {
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CacheHub : Hub {
        public async Task InvalidateCaches(string resource) => await Clients.All.SendAsync("invalidateCache", resource);
    }
}
