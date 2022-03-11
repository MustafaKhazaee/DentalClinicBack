using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Infrastructure.Repository {
    public class AppUserRoleRepository : GenericRepository<AppUserRole>, IAppUserRoleRepository {
        public AppUserRoleRepository (ApplicationDbContext applicationDbContext) : base (applicationDbContext) { }
        public async Task<IEnumerable<AppUserRole>> GetRolesAndPermissionsByUserId(Guid Id) {
            return await Task.FromResult(context.AppUserRoles.Where(aur => aur.AppUserId == Id).Include(aur => aur.Role).
                ThenInclude(r => r.RolePermissions).ThenInclude(rp => rp.Permission).ToList<AppUserRole>());
        }
    }
}
