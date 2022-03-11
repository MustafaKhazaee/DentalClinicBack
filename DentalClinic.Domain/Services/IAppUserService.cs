using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
namespace DentalClinic.Domain.Services {
    public interface IAppUserService {
        public Task<IEnumerable<AppUserRole>> GetRolesAndPermissionsByUserId(Guid Id);
        public Task<IEnumerable<AppUser>> GetAllDoctors();
        public Task<IEnumerable<AppUser>> GetAllEmployees();
        public Task<AppUser> FindByUsernameAsync(string username);
        public Task<PagedResult<AppUser>> GetFilteredPagedAsync(string username, int pageIndex, int pageSize);
        public Task<int> AddAsync(AppUser appUser, IEnumerable<Guid> roles);
        public Task<int> RemoveAsync(Guid Id);
        public Task<int> UpdateAsync(AppUser appUser, IEnumerable<Guid> roles);
        public Task<IEnumerable<Guid>> GetGuidsByRoleName(string rolename);
    }
}
