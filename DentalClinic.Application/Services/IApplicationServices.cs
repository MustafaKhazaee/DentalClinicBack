using DentalClinic.Application.Services.Authentication;
namespace DentalClinic.Application.Services {
    public interface IApplicationServices {
        public IAuthenticationService AuthenticationService { get; set; }
    }
}
