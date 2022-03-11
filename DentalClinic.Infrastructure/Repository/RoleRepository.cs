using DentalClinic.Domain.Common;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Infrastructure.Repository {
    public class RoleRepository : GenericRepository<Role>, IRoleRepository {
        public RoleRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
        public async Task<PagedResult<Role>> GetFilteredPagedAsync(string rolename, int pageIndex, int pageSize) =>
            await context.Roles.Where(r => r.RoleName.Contains(rolename) || rolename.Equals("null"))
                .Include(r => r.RolePermissions).ThenInclude(rp => rp.Permission).GetPaged(pageIndex, pageSize);
    }
}
