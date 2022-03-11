using DentalClinic.Application.Services.Authentication;
using DentalClinic.Domain.Services;
using Microsoft.Extensions.Configuration;
namespace DentalClinic.Application.Services {
    public class ApplicationServices : IApplicationServices {
        public ApplicationServices (IDomainServices _domainServices, IConfiguration _configuration) {
            AuthenticationService = new AuthenticationService(_domainServices, _configuration);
        }
        public IAuthenticationService? AuthenticationService { get; set; }
    }
}
