using System.Text;
using System.Security.Claims;
using DentalClinic.Domain.Enums;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Services;
using Microsoft.IdentityModel.Tokens;
using DentalClinic.Application.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using DentalClinic.Application.Extensions;
namespace DentalClinic.Application.Services.Authentication {
    public class AuthenticationService : IAuthenticationService {
        private readonly IDomainServices DomainServices;
        private readonly IConfiguration Configuration;
        public AuthenticationService(IDomainServices _domainServices, IConfiguration _configuration) {
            DomainServices = _domainServices;
            Configuration = _configuration;
        }
        public async Task<string> Authenticate(LoginModel loginModel) {
            AppUser appUser = await DomainServices.AppUserService.FindByUsernameAsync(loginModel.Username);
            if (appUser == null)
                return await Task.FromResult("User not found");
            else if (appUser.isLocked)
                return await Task.FromResult("User is locked");
            string hashedPassword = $"{loginModel.Password}{appUser.Salt}".GetHash();
            if (loginModel.Username == appUser.UserName && hashedPassword == appUser.Password) {
                List<AppUserRole> userRoles = (List<AppUserRole>) await DomainServices.AppUserService.GetRolesAndPermissionsByUserId(appUser.Id);
                if (userRoles == null || !userRoles.Any())
                    return await Task.FromResult("User has no role");
                List<Role> roles = new List<Role>();
                List<Permission> permissions = new List<Permission>();
                userRoles.ForEach(r => {
                    roles.Add(r.Role);
                    r.Role.RolePermissions.ToList().ForEach(rp => {
                        permissions.Add(rp.Permission);
                    });
                });
                if (!permissions.Any())
                    return await Task.FromResult("User has no permission");
                return await GenerateJWT(appUser, roles, permissions);
            }
            return await Task.FromResult("Invalid password");
        }
        private async Task<string> GenerateJWT (AppUser appUser, List<Role> roles, List<Permission> permissions) {
            var securityKey = new SymmetricSecurityKey(Encoding.Unicode.GetBytes(Configuration["Jwt:IssuerSigninKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = await GetClaims(appUser, roles, permissions);
            var token = new JwtSecurityToken(Configuration["Jwt:ValidIssuer"], Configuration["Jwt:ValidAudience"],
                claims, null, DateTime.Now.AddHours(2), credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private async Task<List<Claim>> GetClaims(AppUser appUser, List<Role> roles, List<Permission> permissions) {
            List<Claim> claimList = new List<Claim>();
            switch (appUser.UserType) {
                case UserType.Doctor:
                    Doctor doctor = await DomainServices.DoctorService.FindByUserId(appUser.Id);
                    claimList = GenerateClaims(appUser.Id, doctor != null ? doctor.FirstName : appUser.UserName,
                                               doctor != null ? doctor.LastName : "", roles, permissions);
                    break;
                case UserType.Employee:
                    Employee employee = await DomainServices.EmployeeService.FindByUserId(appUser.Id);
                    claimList = GenerateClaims(appUser.Id, employee != null ? employee.FirstName : appUser.UserName,
                                               employee != null ? employee.LastName : "", roles, permissions);
                    break;
            }
            return claimList;
        }
        private List<Claim> GenerateClaims(Guid Id, string firstname, string lastname, List<Role> roles, List<Permission> permissions) {
            List<Claim> claims = new List<Claim>();// Doctor, Employee, etc ...
            claims.Add(new Claim(ClaimTypes.Sid, Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, firstname));
            claims.Add(new Claim(ClaimTypes.Surname, lastname));
            permissions.ForEach(p => claims.Add(new Claim(ClaimTypes.Role, p.Code)));
            roles.ForEach(r => claims.Add(new Claim(ClaimTypes.NameIdentifier, r.RoleName)));
            return claims;
        }
    }
}
