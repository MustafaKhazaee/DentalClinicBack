using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Infrastructure.Repository {
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository {
        public AppUserRepository(ApplicationDbContext applicationDbContext) : base (applicationDbContext) { }
        public async Task<PagedResult<AppUser>> GetFilteredPagedAsync(string username, int pageIndex, int pageSize) =>
            await context.AppUsers.Where<AppUser>(u => u.UserName.Contains(username) || username.Equals("null"))
                            .GetPaged<AppUser>(pageIndex, pageSize);

        public async Task<IEnumerable<Guid>> GetGuidsByRoleName(string rolename) {
            List<AppUserRole> ar = await Task.FromResult(context.AppUserRoles.Include(aur => aur.Role)
                .Where(aur => aur.Role.RoleName == rolename).Select(aur => new AppUserRole { AppUserId = aur.AppUserId })
                .ToList());
            List<Guid> guids = new List<Guid>();
            foreach (var userRole in ar) {
                guids.Add(userRole.AppUserId);
            }
            return guids;
        }
    }
}
