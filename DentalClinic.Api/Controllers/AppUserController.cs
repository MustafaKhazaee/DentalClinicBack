using Microsoft.AspNetCore.Mvc;
using DentalClinic.Domain.Services;
using DentalClinic.Application.Services;
using DentalClinic.Domain.Entities;
using DentalClinic.Application.Models;
using Microsoft.AspNetCore.Authorization;
using DentalClinic.Domain.Static;
using DentalClinic.Domain.Common;
namespace DentalClinic.Api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class AppUserController : BaseController {
        public AppUserController(IDomainServices domainServices, IApplicationServices applicationServices) : base (domainServices, applicationServices) { }
        
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<object> Login(LoginModel loginModel) =>
            new { Response = await applicationServices.AuthenticationService.Authenticate(loginModel) };

        [HttpGet]
        [Authorize(Roles = Permissions.AppUser.Get)]
        public async Task<PagedResult<AppUser>> GetFilteredPagedAsync(string username, int pageIndex, int pageSize) =>
            await domainServices.AppUserService.GetFilteredPagedAsync(username, pageIndex, pageSize);

        [HttpGet("allDoctors")]
        [Authorize(Roles = Permissions.AppUser.Get)]
        public async Task<IEnumerable<AppUser>> GetAllDoctors() => await domainServices.AppUserService.GetAllDoctors();

        [HttpGet("allEmployees")]
        [Authorize(Roles = Permissions.AppUser.Get)]
        public async Task<IEnumerable<AppUser>> GetAllEmployees() => await domainServices.AppUserService.GetAllEmployees();

        [HttpPost]
        [Authorize(Roles = Permissions.AppUser.Post)]
        public async Task<int> Add(AppUser appUser,[FromQuery] IEnumerable<Guid> roles) =>
            await domainServices.AppUserService.AddAsync(appUser, roles);

        [HttpPut]
        [Authorize(Roles = Permissions.AppUser.Put)]
        public async Task<int> Put(AppUser appUser, [FromQuery] IEnumerable<Guid> roles) => 
            await domainServices.AppUserService.UpdateAsync(appUser, roles);

        [HttpDelete]
        [Authorize(Roles = Permissions.AppUser.Delete)]
        public async Task<int> Delete(Guid id) => await domainServices.AppUserService.RemoveAsync(id);
    }
}
