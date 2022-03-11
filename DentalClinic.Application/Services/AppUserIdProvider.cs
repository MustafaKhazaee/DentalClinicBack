using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
namespace DentalClinic.Application.Services {
    public class AppUserIdProvider : IUserIdProvider {
        public virtual string GetUserId(HubConnectionContext connection) =>
            connection.User.Claims.First(c => c.Type == ClaimTypes.Sid).Value;
    }
}
