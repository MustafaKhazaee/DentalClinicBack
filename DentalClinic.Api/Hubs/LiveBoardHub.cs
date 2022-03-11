using DentalClinic.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
namespace DentalClinic.Api.Hubs {
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LiveBoardHub : Hub {
        private readonly IDomainServices domainServices;
        public LiveBoardHub(IDomainServices _domainServices) { domainServices = _domainServices; }
        public async Task GetTodaysVisits() => 
            await Clients.All.SendAsync("updateVisitBoard", await domainServices.VisitService.GetTodaysVisits());
    }
}
