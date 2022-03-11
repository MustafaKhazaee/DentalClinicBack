using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Services;
using DentalClinic.Domain.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace DentalClinic.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController {
        public RoleController (IDomainServices domainServices) : base (domainServices) { }

        [HttpGet]
        [Authorize(Roles = Permissions.Role.Get)]
        public async Task<PagedResult<Role>> GetFilteredPagedAsync(string rolename, int pageIndex, int pageSize) =>
            await domainServices.RoleService.GetFilteredPagedAsync(rolename, pageIndex, pageSize);

        [HttpGet("All")]
        [Authorize(Roles = Permissions.Role.Get)]
        public async Task<IEnumerable<Role>> GetAll() => await domainServices.RoleService.GetAllAsync();

        [HttpPost]
        [Authorize(Roles = Permissions.Role.Post)]
        public async Task<int> Add(string rolename, IEnumerable<string> list) => 
            await domainServices.RoleService.AddAsync(rolename, list);

        [HttpPut]
        [Authorize(Roles = Permissions.Role.Put)]
        public async Task<int> Update(Guid Id, string rolename, IEnumerable<string> list) =>
            await domainServices.RoleService.UpdateAsync(Id, rolename, list);

        [HttpDelete]
        [Authorize(Roles = Permissions.Role.Delete)]
        public async Task Delete(Guid Id) => await domainServices.RoleService.RemoveAsync(Id);
    }
}
