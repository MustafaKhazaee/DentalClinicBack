using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Repository;
namespace DentalClinic.Infrastructure.Repository {
    public class RolePermissionRepository : GenericRepository<RolePermission>, IRolePermissionRepository {
        public RolePermissionRepository (ApplicationDbContext applicationDbContext) : base (applicationDbContext) { }
    }
}
