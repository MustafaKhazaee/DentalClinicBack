using DentalClinic.Application.Models;
namespace DentalClinic.Application.Services.Authentication {
    public interface IAuthenticationService {
        public Task<string> Authenticate(LoginModel loginModel);
    }
}
